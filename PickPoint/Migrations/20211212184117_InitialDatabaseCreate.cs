using Microsoft.EntityFrameworkCore.Migrations;

namespace PickPoint.Migrations
{
    public partial class InitialDatabaseCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postamats",
                columns: table => new
                {
                    PostamatNumber = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postamats", x => x.PostamatNumber);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatusId = table.Column<int>(nullable: false),
                    Check = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PostamatId = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    RecipientName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Postamats_PostamatId",
                        column: x => x.PostamatId,
                        principalTable: "Postamats",
                        principalColumn: "PostamatNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goods_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goods_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Зарегистрирован" },
                    { 2, "Принят на складе" },
                    { 3, "Выдан курьеру" },
                    { 4, "Доставлен в постамат" },
                    { 5, "Доставлен получателю" },
                    { 6, "Отменен" }
                });

            migrationBuilder.InsertData(
                table: "Postamats",
                columns: new[] { "PostamatNumber", "Address", "Status" },
                values: new object[,]
                {
                    { "1111-111", "Дом 1", true },
                    { "2222-222", "Дом 2", false },
                    { "3333-333", "Дом 3", true }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ProductName" },
                values: new object[,]
                {
                    { 1, "Ноутбук" },
                    { 2, "Телефон" },
                    { 3, "Машина" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Check", "OrderStatusId", "PhoneNumber", "PostamatId", "RecipientName" },
                values: new object[,]
                {
                    { 1, 1000m, 1, "+79546511269", "1111-111", "Антон" },
                    { 2, 2000m, 2, "+79651651269", "1111-111", "Иван" },
                    { 5, 5000m, 5, "+79598410324", "1111-111", "Игорь" },
                    { 3, 3000m, 3, "+79546516512", "2222-222", "Григорий" },
                    { 6, 6000m, 6, "+76541980098", "2222-222", "Кикита" },
                    { 4, 4000m, 4, "+79500232695", "3333-333", "Степан" }
                });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 8, 5, 1 },
                    { 9, 5, 2 },
                    { 10, 5, 3 },
                    { 4, 3, 1 },
                    { 11, 6, 1 },
                    { 12, 6, 3 },
                    { 13, 6, 2 },
                    { 14, 6, 3 },
                    { 5, 4, 3 },
                    { 6, 4, 2 },
                    { 7, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_OrderId",
                table: "Goods",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_ProductId",
                table: "Goods",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PostamatId",
                table: "Orders",
                column: "PostamatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Postamats");
        }
    }
}
