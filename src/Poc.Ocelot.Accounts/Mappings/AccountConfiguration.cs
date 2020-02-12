using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.Ocelot.Accounts.Extensions;
using Poc.Ocelot.Accounts.Models;

namespace Poc.Ocelot.Accounts.Mappings
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.Property(x => x.Id).ValueGeneratedNever().HasColumnName("Id_Account");
            builder.Property(x => x.Email).HasColumnType("NVARCHAR(256)").HasColumnName("Email_Account").IsRequired();
            builder.Property(x => x.Password).HasColumnType("NVARCHAR(MAX)").HasColumnName("Password_Account").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnType("datetime").HasColumnName("CreatedAt_Account").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnType("datetime").HasColumnName("UpdatedAt_Account").IsRequired();

            builder.HasData(
                new Account()
                {
                    Email = "leaosomogyi@hotmail.com",
                    Password = "@Abc1234".Cript()
                }
            );
        }
    }
}
