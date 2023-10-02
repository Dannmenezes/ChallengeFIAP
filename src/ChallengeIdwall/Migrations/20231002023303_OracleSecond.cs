using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeIdwall.Migrations
{
    /// <inheritdoc />
    public partial class OracleSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InterpolEntityId",
                table: "FBITable",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Interpol",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "InterpolTable",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Forename = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Nationalities = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterpolTable", x => x.EntityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FBITable_InterpolEntityId",
                table: "FBITable",
                column: "InterpolEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FBITable_InterpolTable_InterpolEntityId",
                table: "FBITable",
                column: "InterpolEntityId",
                principalTable: "InterpolTable",
                principalColumn: "EntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FBITable_InterpolTable_InterpolEntityId",
                table: "FBITable");

            migrationBuilder.DropTable(
                name: "Interpol");

            migrationBuilder.DropTable(
                name: "InterpolTable");

            migrationBuilder.DropIndex(
                name: "IX_FBITable_InterpolEntityId",
                table: "FBITable");

            migrationBuilder.DropColumn(
                name: "InterpolEntityId",
                table: "FBITable");
        }
    }
}
