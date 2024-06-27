using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryDAL.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Title", "copyId" },
                values: new object[,]
                {
                    { 1, "Clean Code", 0 },
                    { 2, "Algorithms", 0 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name", "phoneNumber" },
                values: new object[,]
                {
                    { 1, "ali@enozom.com", "Ali", 122224400 },
                    { 2, "mohammed@enozom.com", "Mohammed", 111155000 },
                    { 3, "ahmed@enozom.com", "Ahmed", 155553311 }
                });

            migrationBuilder.InsertData(
                table: "BookCopies",
                columns: new[] { "Id", "BookId", "status" },
                values: new object[,]
                {
                    { 1, 1, "Good" },
                    { 2, 2, "Damaged" },
                    { 3, 1, "Borrowed" }
                });

            migrationBuilder.InsertData(
                table: "BorrowRecords",
                columns: new[] { "Id", "CopyId", "ReturnStatus", "StudentId", "actualReturnDate", "borrowedDate", "expectedReturnDate" },
                values: new object[] { 1, 3, null, 1, null, new DateTime(2024, 6, 22, 16, 28, 59, 154, DateTimeKind.Local).AddTicks(8073), new DateTime(2024, 7, 7, 16, 28, 59, 154, DateTimeKind.Local).AddTicks(8127) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BorrowRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
