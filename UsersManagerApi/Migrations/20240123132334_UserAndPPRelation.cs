using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersManagerApi.Migrations
{
    public partial class UserAndPPRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_PhysicalPerson_PhysicalPersonId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_PhysicalPerson_PhysicalPersonId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalPerson_Users_UserId",
                table: "PhysicalPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhysicalPerson",
                table: "PhysicalPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "PhysicalPerson",
                newName: "PhysicalPersons");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_PhysicalPerson_UserId",
                table: "PhysicalPersons",
                newName: "IX_PhysicalPersons_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_PhysicalPersonId",
                table: "Contacts",
                newName: "IX_Contacts_PhysicalPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_PhysicalPersonId",
                table: "Addresses",
                newName: "IX_Addresses_PhysicalPersonId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "PhysicalPersons",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhysicalPersons",
                table: "PhysicalPersons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalPersons_Users_UserId",
                table: "PhysicalPersons",
                column: "UserId",
                principalTable: "Users",
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

            migrationBuilder.DropForeignKey(
                name: "FK_PhysicalPersons_Users_UserId",
                table: "PhysicalPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhysicalPersons",
                table: "PhysicalPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "PhysicalPersons",
                newName: "PhysicalPerson");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_PhysicalPersons_UserId",
                table: "PhysicalPerson",
                newName: "IX_PhysicalPerson_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_PhysicalPersonId",
                table: "Contact",
                newName: "IX_Contact_PhysicalPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_PhysicalPersonId",
                table: "Address",
                newName: "IX_Address_PhysicalPersonId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "PhysicalPerson",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhysicalPerson",
                table: "PhysicalPerson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_PhysicalPerson_PhysicalPersonId",
                table: "Address",
                column: "PhysicalPersonId",
                principalTable: "PhysicalPerson",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_PhysicalPerson_PhysicalPersonId",
                table: "Contact",
                column: "PhysicalPersonId",
                principalTable: "PhysicalPerson",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalPerson_Users_UserId",
                table: "PhysicalPerson",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
