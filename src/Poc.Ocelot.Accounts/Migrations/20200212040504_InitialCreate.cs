using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poc.Ocelot.Accounts.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id_Account = table.Column<Guid>(nullable: false),
                    Email_Account = table.Column<string>(type: "NVARCHAR(256)", nullable: false),
                    Password_Account = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CreatedAt_Account = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt_Account = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id_Account);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id_Account", "CreatedAt_Account", "Email_Account", "Password_Account", "UpdatedAt_Account" },
                values: new object[] { new Guid("8d47f6ea-7202-448c-ab56-125365e10562"), "2020-02-12T01:48:25.682Z", "leaosomogyi@hotmail.com", "190142EF04881B893D77A5C76AD8EAA10272BB8F", "2020-02-12T01:48:25.682Z" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
