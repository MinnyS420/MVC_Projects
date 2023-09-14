using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEDC.BurgerApp.DataAccess.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burgers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsVegetarian = table.Column<bool>(type: "bit", nullable: false),
                    IsVegan = table.Column<bool>(type: "bit", nullable: false),
                    HasFries = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burgers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpensAt = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClosesAt = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BurgerOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurgerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurgerOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BurgerOrder_Burgers_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burgers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BurgerOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Burgers",
                columns: new[] { "Id", "HasFries", "IsVegan", "IsVegetarian", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, false, false, "Chicken Burger", 2.0 },
                    { 2, true, false, false, "Ham Burger", 3.0 },
                    { 3, true, false, true, "Veggie Burger", 2.0 },
                    { 4, true, false, false, "Cheeseburger", 3.5 },
                    { 5, true, false, false, "Double Cheeseburger", 5.0 },
                    { 6, true, false, false, "Bacon Burger", 4.5 },
                    { 7, true, false, false, "Fish Burger", 3.7999999999999998 },
                    { 8, true, true, true, "Mushroom Burger", 3.2000000000000002 },
                    { 9, true, false, false, "BBQ Burger", 4.0 },
                    { 10, true, true, true, "Vegan Burger", 3.5 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "ClosesAt", "Name", "OpensAt" },
                values: new object[,]
                {
                    { 1, "Skopje", new TimeSpan(0, 22, 0, 0, 0), "Tehno Burgeri", new TimeSpan(0, 7, 0, 0, 0) },
                    { 2, "Bitola", new TimeSpan(0, 22, 0, 0, 0), "Anhoch Burgeri", new TimeSpan(0, 7, 0, 0, 0) },
                    { 3, "Veles", new TimeSpan(0, 22, 0, 0, 0), "Setek Burgeri", new TimeSpan(0, 7, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "FullName", "IsDelivered", "LocationId" },
                values: new object[] { 1, "Ilinden", "Bob Bobsky", true, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "FullName", "IsDelivered", "LocationId" },
                values: new object[] { 2, "Marion", "Boki Boksan", false, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "FullName", "IsDelivered", "LocationId" },
                values: new object[] { 3, "Marion", "Jhon Wick", false, 3 });

            migrationBuilder.InsertData(
                table: "BurgerOrder",
                columns: new[] { "Id", "BurgerId", "OrderId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 3, 3, 2 },
                    { 4, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BurgerOrder_BurgerId",
                table: "BurgerOrder",
                column: "BurgerId");

            migrationBuilder.CreateIndex(
                name: "IX_BurgerOrder_OrderId",
                table: "BurgerOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LocationId",
                table: "Orders",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BurgerOrder");

            migrationBuilder.DropTable(
                name: "Burgers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
