using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitApi.Migrations
{
    public partial class initialFruit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fruit");

            migrationBuilder.CreateTable(
                name: "Fruit",
                schema: "fruit",
                columns: table => new
                {
                    FruitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKNC_Fruit_FruitId", x => x.FruitId)
                        .Annotation("SqlServer:Clustered", false);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fruit",
                schema: "fruit");
        }
    }
}
