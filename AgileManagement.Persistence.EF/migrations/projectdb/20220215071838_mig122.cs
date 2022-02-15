using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileManagement.Persistence.EF.migrations.projectdb
{
    public partial class mig122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SprintNo",
                table: "Sprint");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Sprint",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Sprint",
                newName: "isActive");

            migrationBuilder.AddColumn<int>(
                name: "SprintNo",
                table: "Sprint",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
