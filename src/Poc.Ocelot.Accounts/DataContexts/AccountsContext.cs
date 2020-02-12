using Microsoft.EntityFrameworkCore;
using Poc.Ocelot.Accounts.Mappings;
using Poc.Ocelot.Accounts.Models;

namespace Poc.Ocelot.Accounts.DataContexts
{
    public class AccountsContext : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }

        public AccountsContext(DbContextOptions<AccountsContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}
