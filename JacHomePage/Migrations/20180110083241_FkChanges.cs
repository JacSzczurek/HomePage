using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JacHomePage.Migrations
{
    public partial class FkChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Offers_OfferId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Offers_OfferId",
                table: "Contacts",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Offers_OfferId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Offers_OfferId",
                table: "Contacts",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
