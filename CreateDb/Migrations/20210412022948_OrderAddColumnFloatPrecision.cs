using Microsoft.EntityFrameworkCore.Migrations;

namespace CreateDb.Migrations
{
    public partial class OrderAddColumnFloatPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FloatPrecision",
                schema: "dbo",
                table: "Order",
                type: "numeric(12,10)",
                nullable: false,
                defaultValue: 0m,
                comment: "浮點數解析度");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FloatPrecision",
                schema: "dbo",
                table: "Order");
        }
    }
}
