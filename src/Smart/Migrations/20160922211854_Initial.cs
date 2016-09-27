using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Smart.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bowl",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlertAmount = table.Column<decimal>(nullable: false),
                    FoodAmount = table.Column<decimal>(nullable: false),
                    FoodName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bowl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Breed = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Weight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BowlPet",
                columns: table => new
                {
                    PetId = table.Column<int>(nullable: false),
                    BowlId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BowlPet", x => new { x.PetId, x.BowlId });
                    table.ForeignKey(
                        name: "FK_BowlPet_Bowl_BowlId",
                        column: x => x.BowlId,
                        principalTable: "Bowl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BowlPet_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BowlPet_BowlId",
                table: "BowlPet",
                column: "BowlId");

            migrationBuilder.CreateIndex(
                name: "IX_BowlPet_PetId",
                table: "BowlPet",
                column: "PetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BowlPet");

            migrationBuilder.DropTable(
                name: "Bowl");

            migrationBuilder.DropTable(
                name: "Pet");
        }
    }
}
