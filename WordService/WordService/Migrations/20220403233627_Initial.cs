using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SingleWords",
                columns: table => new
                {
                    Word = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleWords", x => x.Word);
                });

            migrationBuilder.InsertData(
                table: "SingleWords",
                columns: new[] { "Word", "Count" },
                values: new object[,]
                {
                    { "filter", 0 },
                    { "goodbye", 0 },
                    { "hello", 0 },
                    { "list", 0 },
                    { "no", 0 },
                    { "search", 0 },
                    { "simple", 0 },
                    { "yes", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SingleWords");
        }
    }
}
