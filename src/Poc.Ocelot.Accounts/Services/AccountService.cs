using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Poc.Ocelot.Accounts.Constants;
using Poc.Ocelot.Accounts.Interfaces.Repositories;
using Poc.Ocelot.Accounts.Interfaces.Services;
using Poc.Ocelot.Accounts.Models;

namespace Poc.Ocelot.Accounts.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AppSettings _appSettings;

        public AccountService(IAccountRepository accountRepository, IOptions<AppSettings> options)
        {
            _accountRepository = accountRepository;
            _appSettings = options.Value;
        }

        public async Task<Token> Authenticate(Account account, string claimPermission)
        {
            var _account = await _accountRepository.FindToLoginAsync(account.Email, account.Password);
            if (_account != null)
            {
                var now = DateTime.Now;

                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _account.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, _account.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(AppConstants.PERMISSION_CLAIM, claimPermission)
                };

                var expires = DateTime.Now.AddSeconds(_appSettings.Tokens.Lifetime);
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Tokens.Key));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                var jwt = new JwtSecurityToken(
                    signingCredentials: signingCredentials,
                    claims: claims,
                    expires: expires,
                    audience: _appSettings.Tokens.Audience,
                    issuer: _appSettings.Tokens.Issuer);

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                return new Token()
                {
                    AccessToken = token,
                    Authenticated = true,
                    CreatedAt = now,
                    ExpiresAt = expires
                };
            }
            else
            {
                throw new ArgumentException("User or password not found!");
            }
        }
    }
}
