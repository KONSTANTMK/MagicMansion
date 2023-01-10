using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicMansionMansionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMansionNumbersWithoutPropsV2ToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VillaNo",
                table: "MansionNumbers",
                newName: "MansionNo");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MansionNo",
                table: "MansionNumbers",
                newName: "VillaNo");

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
    }
}
