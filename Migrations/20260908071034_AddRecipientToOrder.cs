using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace helloapp.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipientToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipientName",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientName",
                table: "Orders");
        }
    }
}
