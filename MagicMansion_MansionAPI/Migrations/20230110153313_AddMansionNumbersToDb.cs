using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicMansionMansionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMansionNumbersToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MansionNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaID = table.Column<int>(type: "int", nullable: false),
                    MansionId = table.Column<int>(type: "int", nullable: true),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MansionNumbers", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_MansionNumbers_Mansions_MansionId",
                        column: x => x.MansionId,
                        principalTable: "Mansions",
                        principalColumn: "Id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MansionNumbers");

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 19, 29, 22, 560, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 19, 29, 22, 560, DateTimeKind.Local).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 19, 29, 22, 560, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 19, 29, 22, 560, DateTimeKind.Local).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 8, 19, 29, 22, 560, DateTimeKind.Local).AddTicks(7404));
        }
    }
}
