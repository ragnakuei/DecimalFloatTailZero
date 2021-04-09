using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreateDb.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Guid"),
                    SubTotal = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "小計"),
                    BusinessTax = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "營業稅"),
                    Total = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "總計")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_Order_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Guid"),
                    OrderGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "訂單 Guid"),
                    UnitPrice = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, comment: "單價"),
                    Count = table.Column<int>(type: "int", nullable: false, comment: "數量"),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "備註")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_OrderDetail_OrderGuid_Order_Guid",
                        column: x => x.OrderGuid,
                        principalSchema: "dbo",
                        principalTable: "Order",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Guid",
                schema: "dbo",
                table: "Order",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_Guid",
                schema: "dbo",
                table: "OrderDetail",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderGuid",
                schema: "dbo",
                table: "OrderDetail",
                column: "OrderGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");
        }
    }
}
