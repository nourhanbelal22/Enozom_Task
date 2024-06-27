using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 2,
                column: "status",
                value: "Good");

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 3,
                column: "status",
                value: "Good");

            migrationBuilder.UpdateData(
                table: "BorrowRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "borrowedDate", "expectedReturnDate" },
                values: new object[] { new DateTime(2024, 6, 22, 17, 14, 15, 766, DateTimeKind.Local).AddTicks(6315), new DateTime(2024, 7, 7, 17, 14, 15, 766, DateTimeKind.Local).AddTicks(6385) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 2,
                column: "status",
                value: "Damaged");

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 3,
                column: "status",
                value: "Borrowed");

            migrationBuilder.UpdateData(
                table: "BorrowRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "borrowedDate", "expectedReturnDate" },
                values: new object[] { new DateTime(2024, 6, 22, 16, 28, 59, 154, DateTimeKind.Local).AddTicks(8073), new DateTime(2024, 7, 7, 16, 28, 59, 154, DateTimeKind.Local).AddTicks(8127) });
        }
    }
}
