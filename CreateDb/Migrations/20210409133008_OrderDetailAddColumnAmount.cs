using Microsoft.EntityFrameworkCore.Migrations;

namespace CreateDb.Migrations
{
    public partial class OrderDetailAddColumnAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Amount",
                schema: "dbo",
                table: "OrderDetail",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "金額");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "dbo",
                table: "OrderDetail");
        }
    }
}
