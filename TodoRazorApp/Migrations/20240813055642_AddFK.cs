using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoRazorApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Todo");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_AccountId",
                table: "Todo",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Account_AccountId",
                table: "Todo",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Account_AccountId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_AccountId",
                table: "Todo");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Todo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
