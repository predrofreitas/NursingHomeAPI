using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CriaElderlyMedication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalMedications");

            migrationBuilder.CreateTable(
                name: "ElderlyMedications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElderlyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MedicationRoute = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElderlyMedications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElderlyMedications_Elderlies_ElderlyId",
                        column: x => x.ElderlyId,
                        principalTable: "Elderlies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElderlyMedications_ElderlyId",
                table: "ElderlyMedications",
                column: "ElderlyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElderlyMedications");

            migrationBuilder.CreateTable(
                name: "PersonalMedications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElderlyId = table.Column<int>(type: "int", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MedicationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalMedications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalMedications_Elderlies_ElderlyId",
                        column: x => x.ElderlyId,
                        principalTable: "Elderlies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMedications_ElderlyId",
                table: "PersonalMedications",
                column: "ElderlyId");
        }
    }
}
