using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Migrations
{
    /// <inheritdoc />
    public partial class MigrationBread : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreadId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Breads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breads", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BreadId",
                table: "Pets",
                column: "BreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breads_BreadId",
                table: "Pets",
                column: "BreadId",
                principalTable: "Breads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breads_BreadId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Breads");

            migrationBuilder.DropIndex(
                name: "IX_Pets_BreadId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BreadId",
                table: "Pets");
        }
    }
}
