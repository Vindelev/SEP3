﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Main : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rides",
                columns: table => new
                {
                    RideId = table.Column<string>(nullable: false),
                    Driver = table.Column<string>(nullable: true),
                    Seats = table.Column<int>(nullable: false),
                    DeparturePoint = table.Column<string>(nullable: true),
                    DestinationCity = table.Column<string>(nullable: true),
                    DestinationAddr = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.RideId);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    RideId = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.RideId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rides");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
