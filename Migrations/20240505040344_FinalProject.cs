using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewSound.Migrations
{
    public partial class FinalProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bar",
                columns: table => new
                {
                    BarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alkohol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredient = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bar", x => x.BarID);
                });

            migrationBuilder.CreateTable(
                name: "ConcertHall",
                columns: table => new
                {
                    ConcertHallID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxAmount = table.Column<int>(type: "int", nullable: false),
                    BarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertHall", x => x.ConcertHallID);
                    table.ForeignKey(
                        name: "FK_ConcertHall_Bar_BarID",
                        column: x => x.BarID,
                        principalTable: "Bar",
                        principalColumn: "BarID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cuisine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mile = table.Column<int>(type: "int", nullable: false),
                    ConcertHallID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.RestaurantID);
                    table.ForeignKey(
                        name: "FK_Restaurant_ConcertHall_ConcertHallID",
                        column: x => x.ConcertHallID,
                        principalTable: "ConcertHall",
                        principalColumn: "ConcertHallID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcertHallID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Ticket_ConcertHall_ConcertHallID",
                        column: x => x.ConcertHallID,
                        principalTable: "ConcertHall",
                        principalColumn: "ConcertHallID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcertHall_BarID",
                table: "ConcertHall",
                column: "BarID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_ConcertHallID",
                table: "Restaurant",
                column: "ConcertHallID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ConcertHallID",
                table: "Ticket",
                column: "ConcertHallID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "ConcertHall");

            migrationBuilder.DropTable(
                name: "Bar");
        }
    }
}
