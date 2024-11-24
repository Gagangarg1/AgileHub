using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgileHub.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avatars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstimationSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Values = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimationSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimationSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnyOneCanRevealCards = table.Column<bool>(type: "bit", nullable: false),
                    EveryoneIsAllowedToManageStories = table.Column<bool>(type: "bit", nullable: false),
                    AutoRevealCards = table.Column<bool>(type: "bit", nullable: false),
                    EnableAnimation = table.Column<bool>(type: "bit", nullable: false),
                    ShowTimer = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningRooms_EstimationSystems_EstimationSystemId",
                        column: x => x.EstimationSystemId,
                        principalTable: "EstimationSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JiraId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanningRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stories_PlanningRooms_PlanningRoomId",
                        column: x => x.PlanningRoomId,
                        principalTable: "PlanningRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlanningRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Avatars_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Avatars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_PlanningRooms_PlanningRoomId",
                        column: x => x.PlanningRoomId,
                        principalTable: "PlanningRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoryPoint = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votes_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstimationSystems",
                columns: new[] { "Id", "Name", "Values" },
                values: new object[,]
                {
                    { new Guid("1a947dcb-463d-43a3-868e-ca1f9b65461f"), "Sequential", "[\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"10\",\"11\",\"12\",\"13\",\"Coffee\"]" },
                    { new Guid("37005290-7729-4dd9-a3ec-22047d5ba636"), "Scrum", "[\"1/2\",\"1\",\"2\",\"3\",\"5\",\"8\",\"13\",\"20\",\"40\",\"100\",\"Coffee\"]" },
                    { new Guid("69d1b033-099e-41e9-8e13-2ddeb98a4095"), "Fibonacci", "[\"1\",\"3\",\"5\",\"8\",\"13\",\"21\",\"34\",\"Coffee\"]" },
                    { new Guid("a4721373-cc8f-43c0-81a6-60676d2c024c"), "T-Shirt", "[\"XS\",\"S\",\"M\",\"L\",\"XL\",\"XXL\",\"XXXL\",\"Coffeee\"]" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRooms_EstimationSystemId",
                table: "PlanningRooms",
                column: "EstimationSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_PlanningRoomId",
                table: "Stories",
                column: "PlanningRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AvatarId",
                table: "Users",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PlanningRoomId",
                table: "Users",
                column: "PlanningRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_StoryId",
                table: "Votes",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Avatars");

            migrationBuilder.DropTable(
                name: "PlanningRooms");

            migrationBuilder.DropTable(
                name: "EstimationSystems");
        }
    }
}
