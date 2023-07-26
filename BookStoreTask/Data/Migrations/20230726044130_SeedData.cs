using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "9780061120084",
                columns: new[] { "NoOfAvailableCopies", "NoOfCopies" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ISBN", "ImageName", "Title", "NoOfAvailableCopies", "NoOfCopies" },
                values: new object[,]
                {
                    { "9780060915544", "meditations.jpg", "Meditations", 5, 5 },
                    { "9780060935467", "one-hunderd-years.jpg", "One Hundred Years of Solitude", 4, 4 },
                    { "9780061120060", "tom-sawyer.jpg", "The Adventures of Tom Sawyer", 4, 4 },
                    { "9780062220509", "jane-eyre.jpg", "Jane Eyre", 4, 4 },
                    { "9780062315007", "the-book-of-the-five-rings.jpg", "The Book Of The Five Rings", 4, 4 },
                    { "9780062561029", "the-brothers-karmazov.jpg", "The Brothers karamazov", 4, 4 },
                    { "9780141187761", "the-odyssey.jpg", "The Odyssey", 4, 4 },
                    { "9780316066525", "the-divine-comedy.jpg", "The Divine Comedy", 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "9780060915544");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "9780060935467");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "9780061120060");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "9780062220509");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "9780062315007");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "9780062561029");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "9780141187761");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "9780316066525");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "9780061120084",
                columns: new[] { "NoOfAvailableCopies", "NoOfCopies" },
                values: new object[] { 5, 5 });
        }
    }
}
