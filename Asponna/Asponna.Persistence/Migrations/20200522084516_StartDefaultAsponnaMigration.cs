using Microsoft.EntityFrameworkCore.Migrations;

namespace Asponna.Persistence.Migrations
{
    public partial class StartDefaultAsponnaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskBoard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Position = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskBoard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    TaskBoardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_TaskBoard_TaskBoardId",
                        column: x => x.TaskBoardId,
                        principalTable: "TaskBoard",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_TaskBoardId",
                table: "Card",
                column: "TaskBoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "TaskBoard");
        }
    }
}
