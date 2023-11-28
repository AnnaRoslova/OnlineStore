using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Color", "CompareId", "Compound", "Cost", "Description", "ImagePath", "Manufactured", "Name", "WishListId" },
                values: new object[] { new Guid("df3f8e2f-91d5-465c-a121-0f25e072b32e"), "Черный", null, "Кожа", 1599m, "шлейка длямаленьких собак", "images\\shleika.png", "Монморанси", "Шлейка", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: new Guid("df3f8e2f-91d5-465c-a121-0f25e072b32e"));
        }
    }
}
