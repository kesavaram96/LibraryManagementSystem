using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Data.Migrations
{
    public partial class BooksInventoryLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksInventory_AspNetUsers_UserId",
                table: "BooksInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksInventory_Books_BookId",
                table: "BooksInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksInventory",
                table: "BooksInventory");

            migrationBuilder.RenameTable(
                name: "BooksInventory",
                newName: "BooksInventories");

            migrationBuilder.RenameIndex(
                name: "IX_BooksInventory_UserId",
                table: "BooksInventories",
                newName: "IX_BooksInventories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksInventory_BookId",
                table: "BooksInventories",
                newName: "IX_BooksInventories_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksInventories",
                table: "BooksInventories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInventories_AspNetUsers_UserId",
                table: "BooksInventories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInventories_Books_BookId",
                table: "BooksInventories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksInventories_AspNetUsers_UserId",
                table: "BooksInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksInventories_Books_BookId",
                table: "BooksInventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksInventories",
                table: "BooksInventories");

            migrationBuilder.RenameTable(
                name: "BooksInventories",
                newName: "BooksInventory");

            migrationBuilder.RenameIndex(
                name: "IX_BooksInventories_UserId",
                table: "BooksInventory",
                newName: "IX_BooksInventory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksInventories_BookId",
                table: "BooksInventory",
                newName: "IX_BooksInventory_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksInventory",
                table: "BooksInventory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInventory_AspNetUsers_UserId",
                table: "BooksInventory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksInventory_Books_BookId",
                table: "BooksInventory",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
