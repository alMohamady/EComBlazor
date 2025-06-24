using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EComBlazor.db.Migrations
{
    /// <inheritdoc />
    public partial class userroels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7834acea-66dc-4e5c-8531-1bcaf27509e7", null, "Admin", "ADMIN" },
                    { "a6cd60e6-f32c-4906-9d6f-98e7fa8396b5", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7834acea-66dc-4e5c-8531-1bcaf27509e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6cd60e6-f32c-4906-9d6f-98e7fa8396b5");
        }
    }
}
