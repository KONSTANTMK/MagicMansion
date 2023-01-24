using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicMansionMansionAPI.Migrations
{
    /// <inheritdoc />
    public partial class TestAddMansionsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 1, 25, 0, 47, 59, 339, DateTimeKind.Local).AddTicks(7144), "https://sun9-14.userapi.com/impg/0wx3laWZz-W3ClxGfdu8NfzKB4_IG9wtkhjyLg/WOb7pesENtQ.jpg?size=800x509&quality=95&sign=bcfc866301bd2269c19f794c24d19707&type=album", "Royal mansion" });

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 1, 25, 0, 47, 59, 339, DateTimeKind.Local).AddTicks(7157), "https://sun9-30.userapi.com/impg/-xKq2aYv0vQMhz43SVPaRJvg-txJovhjIB0Kkw/4qHK5FADbpo.jpg?size=800x509&quality=95&sign=6e0ade8c4be3b87f67e281baae33bec8&type=album", "Premium Pool mansion" });

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 1, 25, 0, 47, 59, 339, DateTimeKind.Local).AddTicks(7159), "https://sun9-86.userapi.com/impg/K21KcfdcWKql89Nlv9B6Y5Cgeo7sMIlshAXHfw/D4lcWaxEd0w.jpg?size=800x509&quality=95&sign=4d9ebe62cef615f5592510d3cacb784c&type=album", "Luxury Pool mansion" });

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 1, 25, 0, 47, 59, 339, DateTimeKind.Local).AddTicks(7161), "https://sun9-85.userapi.com/impg/YGMw5mpK17Y1bZIyI-aqVHZ3KLCFFu-Hz7tYxg/CVRKxwkblk0.jpg?size=800x509&quality=95&sign=cc4494bacaf276443a6f504da371b80a&type=album", "Diamond mansion" });

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 1, 25, 0, 47, 59, 339, DateTimeKind.Local).AddTicks(7163), "https://sun9-46.userapi.com/impg/UZGqGTyJoTs-7eB0Yt-Bq5CK3HZRN7GneiOl0g/VghlnFMXU9A.jpg?size=800x509&quality=95&sign=4dd7b21a7c9f62d68d1daf7d5ffcb756&type=album", "Diamond Pool mansion" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 1, 23, 22, 17, 32, 759, DateTimeKind.Local).AddTicks(9347), "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", "Royal Villa" });

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 1, 23, 22, 17, 32, 759, DateTimeKind.Local).AddTicks(9363), "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", "Premium Pool Villa" });

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 1, 23, 22, 17, 32, 759, DateTimeKind.Local).AddTicks(9365), "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", "Luxury Pool Villa" });

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 1, 23, 22, 17, 32, 759, DateTimeKind.Local).AddTicks(9368), "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", "Diamond Villa" });

            migrationBuilder.UpdateData(
                table: "Mansions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 1, 23, 22, 17, 32, 759, DateTimeKind.Local).AddTicks(9370), "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", "Diamond Pool Villa" });
        }
    }
}
