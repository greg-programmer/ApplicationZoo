using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Felin" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Description", "ImagePath", "Name", "SpecieId" },
                values: new object[,]
                {
                    { 1, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", null, "lion", 1 },
                    { 2, 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", null, "guépard", 1 },
                    { 3, 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", null, "panthère", 1 },
                    { 4, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", null, "jaguare", 1 },
                    { 5, 7, "Lorem ipsum dolor sit amet, consectetur adipiscing elit...", null, "tigre", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpecieId",
                table: "Animals",
                column: "SpecieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
