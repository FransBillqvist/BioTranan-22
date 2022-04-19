using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Native = table.Column<string>(type: "TEXT", nullable: true),
                    Texted = table.Column<string>(type: "TEXT", nullable: true),
                    Runtime = table.Column<int>(type: "INTEGER", nullable: false),
                    Director = table.Column<string>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<string>(type: "TEXT", nullable: true),
                    RatingValue = table.Column<double>(type: "REAL", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Plot = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfUses = table.Column<int>(type: "INTEGER", nullable: false),
                    BookedUses = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saloons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Seats = table.Column<int>(type: "INTEGER", nullable: false),
                    OpenFrom = table.Column<int>(type: "INTEGER", nullable: false),
                    ClosedAfter = table.Column<int>(type: "INTEGER", nullable: false),
                    MaintenanceBuffer = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saloons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    TextReview = table.Column<string>(type: "TEXT", nullable: true),
                    PointReview = table.Column<int>(type: "INTEGER", nullable: false),
                    ReserveCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    SaloonId = table.Column<int>(type: "INTEGER", nullable: false),
                    FullDateAndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    BookedSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    IsUsed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Saloons_SaloonId",
                        column: x => x.SaloonId,
                        principalTable: "Saloons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShowId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeatsBooked = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservationCode = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    IsValid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "BookedUses", "Country", "Director", "Genre", "Native", "NumberOfUses", "Plot", "Rating", "RatingValue", "Runtime", "Texted", "Title", "Year" },
                values: new object[] { 1, 0, "USA", "Frank Darabont", "Crime, Drama", "English", 5, "Two imprisoned persons attempt to escape from a maximum security stockade. The last hope for both their release is a double-crossing executioner who has been missing for 30 years.", "R", 9.3000000000000007, 142, "Svenska", "The Shawshank Redemption", 1994 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "BookedUses", "Country", "Director", "Genre", "Native", "NumberOfUses", "Plot", "Rating", "RatingValue", "Runtime", "Texted", "Title", "Year" },
                values: new object[] { 2, 0, "USA", "Francis Ford Coppola", "Crime, Drama", "English", 5, "The New York Mafia", "R", 9.1999999999999993, 175, "English, Svenska", "The Godfather", 1972 });

            migrationBuilder.InsertData(
                table: "Saloons",
                columns: new[] { "Id", "ClosedAfter", "MaintenanceBuffer", "Name", "OpenFrom", "Seats" },
                values: new object[] { 1, 2300, 20, "Tranan", 1000, 45 });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "BookedSeats", "FullDateAndTime", "IsUsed", "MovieId", "Price", "SaloonId" },
                values: new object[] { 1, 0, new DateTime(2022, 4, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 90, 1 });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "BookedSeats", "FullDateAndTime", "IsUsed", "MovieId", "Price", "SaloonId" },
                values: new object[] { 2, 0, new DateTime(2022, 4, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 90, 1 });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "BookedSeats", "FullDateAndTime", "IsUsed", "MovieId", "Price", "SaloonId" },
                values: new object[] { 3, 0, new DateTime(2022, 4, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 90, 1 });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "BookedSeats", "FullDateAndTime", "IsUsed", "MovieId", "Price", "SaloonId" },
                values: new object[] { 4, 0, new DateTime(2022, 4, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 90, 1 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Email", "IsValid", "ReservationCode", "SeatsBooked", "ShowId" },
                values: new object[] { 1, "JanneBonde@hitman.com", true, "ABC123", 5, 1 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Email", "IsValid", "ReservationCode", "SeatsBooked", "ShowId" },
                values: new object[] { 2, "Hipster@Manjaho.se", true, "A1B2C3", 12, 1 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Email", "IsValid", "ReservationCode", "SeatsBooked", "ShowId" },
                values: new object[] { 3, "WillSmith@bitchslap.com", true, "BE8D7K", 6, 1 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Email", "IsValid", "ReservationCode", "SeatsBooked", "ShowId" },
                values: new object[] { 4, "Bert@Stenrik.com", true, "L7N5ER", 41, 2 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Email", "IsValid", "ReservationCode", "SeatsBooked", "ShowId" },
                values: new object[] { 5, "JanEmanuel@NotReallyABillonarie.com", true, "NFD76T", 4, 2 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Email", "IsValid", "ReservationCode", "SeatsBooked", "ShowId" },
                values: new object[] { 6, "Tinder@Swindler.com", true, "J3FF21", 2, 3 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Email", "IsValid", "ReservationCode", "SeatsBooked", "ShowId" },
                values: new object[] { 7, "Larare@Lagstadieskolan.se", true, "Y0LO14", 21, 4 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Email", "IsValid", "ReservationCode", "SeatsBooked", "ShowId" },
                values: new object[] { 8, "JanneOskon@hatarsmabarn.se", true, "B0JG4E", 7, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ShowId",
                table: "Reservations",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieId",
                table: "Shows",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_SaloonId",
                table: "Shows",
                column: "SaloonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Saloons");
        }
    }
}
