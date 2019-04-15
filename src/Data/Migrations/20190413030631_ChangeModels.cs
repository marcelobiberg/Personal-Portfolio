using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Biberg.MyPortfolio.Migrations
{
    public partial class ChangeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectTypesID",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Projects",
                type: "ntext",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "ntext",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 600,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Projects",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "ntext",
                maxLength: 600,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 600);

            migrationBuilder.AddColumn<int>(
                name: "ProjectTypesID",
                table: "Projects",
                nullable: false,
                defaultValue: 0);
        }
    }
}
