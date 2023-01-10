using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicMansionMansionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMansionNumbersWithoutPropsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MansionNumbers_Mansions_MansionId",
                table: "MansionNumbers");

            migrationBuilder.DropIndex(
                name: "IX_MansionNumbers_MansionId",
                table: "MansionNumbers");

            migrationBuilder.DropColumn(
                name: "MansionId",
                table: "MansionNumbers");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "MansionNumbers");

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 36, 32, 654, DateTimeKind.Local).AddTicks(5323));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 36, 32, 654, DateTimeKind.Local).AddTicks(5334));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 36, 32, 654, DateTimeKind.Local).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 36, 32, 654, DateTimeKind.Local).AddTicks(5338));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 36, 32, 654, DateTimeKind.Local).AddTicks(5340));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MansionId",
                table: "MansionNumbers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "MansionNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 33, 13, 54, DateTimeKind.Local).AddTicks(7977));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 33, 13, 54, DateTimeKind.Local).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 33, 13, 54, DateTimeKind.Local).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 33, 13, 54, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 33, 13, 54, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.CreateIndex(
                name: "IX_MansionNumbers_MansionId",
                table: "MansionNumbers",
                column: "MansionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MansionNumbers_Mansions_MansionId",
                table: "MansionNumbers",
                column: "MansionId",
                principalTable: "Mansions",
                principalColumn: "Id");
        }
    }
}
