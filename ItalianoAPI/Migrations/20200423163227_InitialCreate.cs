using Microsoft.EntityFrameworkCore.Migrations;

namespace ItalianoAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DessertMenu",
                columns: table => new
                {
                    DessertId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ImgSrc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DessertMenu", x => x.DessertId);
                });

            migrationBuilder.CreateTable(
                name: "DrinkInfo",
                columns: table => new
                {
                    DrinkId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ImgSrc = table.Column<string>(nullable: true),
                    AvgRating = table.Column<float>(nullable: false),
                    TotalVotes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkInfo", x => x.DrinkId);
                });

            migrationBuilder.CreateTable(
                name: "DrinkMenu",
                columns: table => new
                {
                    DrinkId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ImgSrc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkMenu", x => x.DrinkId);
                });

            migrationBuilder.CreateTable(
                name: "FoodInfo",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ImgSrc = table.Column<string>(nullable: true),
                    AvgRating = table.Column<float>(nullable: false),
                    TotalVotes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodInfo", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "FoodMenu",
                columns: table => new
                {
                    FoodId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ImgSrc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMenu", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "DessertRatings",
                columns: table => new
                {
                    RatingsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rating = table.Column<int>(nullable: false),
                    DessertFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DessertRatings", x => x.RatingsId);
                    table.ForeignKey(
                        name: "FK_DessertRatings_DessertMenu_DessertFK",
                        column: x => x.DessertFK,
                        principalTable: "DessertMenu",
                        principalColumn: "DessertId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrinkRatings",
                columns: table => new
                {
                    RatingsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rating = table.Column<int>(nullable: false),
                    DrinkFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkRatings", x => x.RatingsId);
                    table.ForeignKey(
                        name: "FK_DrinkRatings_DrinkMenu_DrinkFK",
                        column: x => x.DrinkFK,
                        principalTable: "DrinkMenu",
                        principalColumn: "DrinkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodRatings",
                columns: table => new
                {
                    RatingsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rating = table.Column<int>(nullable: false),
                    FoodFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRatings", x => x.RatingsId);
                    table.ForeignKey(
                        name: "FK_FoodRatings_FoodMenu_FoodFK",
                        column: x => x.FoodFK,
                        principalTable: "FoodMenu",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    FoodFK = table.Column<int>(nullable: false),
                    DrinkFK = table.Column<int>(nullable: false),
                    DessertFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_DessertMenu_DessertFK",
                        column: x => x.DessertFK,
                        principalTable: "DessertMenu",
                        principalColumn: "DessertId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_DrinkMenu_DrinkFK",
                        column: x => x.DrinkFK,
                        principalTable: "DrinkMenu",
                        principalColumn: "DrinkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_FoodMenu_FoodFK",
                        column: x => x.FoodFK,
                        principalTable: "FoodMenu",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DessertRatings_DessertFK",
                table: "DessertRatings",
                column: "DessertFK");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkRatings_DrinkFK",
                table: "DrinkRatings",
                column: "DrinkFK");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRatings_FoodFK",
                table: "FoodRatings",
                column: "FoodFK");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DessertFK",
                table: "Orders",
                column: "DessertFK");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DrinkFK",
                table: "Orders",
                column: "DrinkFK");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FoodFK",
                table: "Orders",
                column: "FoodFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DessertRatings");

            migrationBuilder.DropTable(
                name: "DrinkInfo");

            migrationBuilder.DropTable(
                name: "DrinkRatings");

            migrationBuilder.DropTable(
                name: "FoodInfo");

            migrationBuilder.DropTable(
                name: "FoodRatings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DessertMenu");

            migrationBuilder.DropTable(
                name: "DrinkMenu");

            migrationBuilder.DropTable(
                name: "FoodMenu");
        }
    }
}
