using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersManagerApi.Migrations
{
    public partial class PasswordHashSaltSecurity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PwdSalt",
                table: "Users",
                type: "longblob",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PwdSalt",
                table: "Users");
        }
    }
}
