using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicMansionMansionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMansionNumbersWithPropsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MansionID",
                table: "MansionNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 22, 41, 30, 212, DateTimeKind.Local).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 22, 41, 30, 212, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 22, 41, 30, 212, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 22, 41, 30, 212, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 22, 41, 30, 212, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.CreateIndex(
                name: "IX_MansionNumbers_MansionID",
                table: "MansionNumbers",
                column: "MansionID");

            migrationBuilder.AddForeignKey(
                name: "FK_MansionNumbers_Mansions_MansionID",
                table: "MansionNumbers",
                column: "MansionID",
                principalTable: "Mansions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MansionNumbers_Mansions_MansionID",
                table: "MansionNumbers");

            migrationBuilder.DropIndex(
                name: "IX_MansionNumbers_MansionID",
                table: "MansionNumbers");

            migrationBuilder.DropColumn(
                name: "MansionID",
                table: "MansionNumbers");

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 38, 6, 775, DateTimeKind.Local).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 38, 6, 775, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 38, 6, 775, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 38, 6, 775, DateTimeKind.Local).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 10, 21, 38, 6, 775, DateTimeKind.Local).AddTicks(9694));
        }
    }
}
