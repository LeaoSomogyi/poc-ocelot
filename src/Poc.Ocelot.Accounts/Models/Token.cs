using System;

namespace Poc.Ocelot.Accounts.Models
{
    public class Token
    {
        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Indicate if user is authenticated
        /// </summary>
        public bool Authenticated { get; set; }

        /// <summary>
        /// Token creation date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Token expiration date
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        public Token() { }
    }
}
