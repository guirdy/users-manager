using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersManagerApi.Migrations
{
    public partial class ForeignKeyForAddressesAndContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_PhysicalPersons_PhysicalPersonId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PhysicalPersons_PhysicalPersonId",
                table: "Contacts");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhysicalPersonId",
                table: "Contacts",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhysicalPersonId",
                table: "Addresses",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_PhysicalPersons_PhysicalPersonId",
                table: "Addresses",
                column: "PhysicalPersonId",
                principalTable: "PhysicalPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PhysicalPersons_PhysicalPersonId",
                table: "Contacts",
                column: "PhysicalPersonId",
                principalTable: "PhysicalPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_PhysicalPersons_PhysicalPersonId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PhysicalPersons_PhysicalPersonId",
                table: "Contacts");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhysicalPersonId",
                table: "Contacts",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhysicalPersonId",
                table: "Addresses",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_PhysicalPersons_PhysicalPersonId",
                table: "Addresses",
                column: "PhysicalPersonId",
                principalTable: "PhysicalPersons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PhysicalPersons_PhysicalPersonId",
                table: "Contacts",
                column: "PhysicalPersonId",
                principalTable: "PhysicalPersons",
                principalColumn: "Id");
        }
    }
}
