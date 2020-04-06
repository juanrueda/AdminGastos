using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminGastos.Migrations
{
    public partial class RelacionUserGasto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Gastos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_UserId",
                table: "Gastos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_Users_UserId",
                table: "Gastos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_Users_UserId",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_UserId",
                table: "Gastos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Gastos");
        }
    }
}
