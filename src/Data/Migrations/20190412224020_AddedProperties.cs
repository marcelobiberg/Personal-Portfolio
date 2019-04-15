using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Biberg.MyPortfolio.Migrations
{
    public partial class AddedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ApplicationUserID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypesID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_AspNetUsers_ApplicationUserID",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectTypesID",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Skills",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_ApplicationUserID",
                table: "Skills",
                newName: "IX_Skills_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Projects",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ApplicationUserID",
                table: "Projects",
                newName: "IX_Projects_ApplicationUserId");

            migrationBuilder.CreateTable(
                name: "ProjectType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectType", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ApplicationUserId",
                table: "Projects",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_AspNetUsers_ApplicationUserId",
                table: "Skills",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ApplicationUserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_AspNetUsers_ApplicationUserId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "ProjectType");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Skills",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_ApplicationUserId",
                table: "Skills",
                newName: "IX_Skills_ApplicationUserID");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Projects",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ApplicationUserId",
                table: "Projects",
                newName: "IX_Projects_ApplicationUserID");

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypesID",
                table: "Projects",
                column: "ProjectTypesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ApplicationUserID",
                table: "Projects",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypesID",
                table: "Projects",
                column: "ProjectTypesID",
                principalTable: "ProjectTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_AspNetUsers_ApplicationUserID",
                table: "Skills",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
