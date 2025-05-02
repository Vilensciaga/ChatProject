using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdministratorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Administrators",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "Administrators");




            migrationBuilder.AddColumn<int>(
                name: "AdministratorId",
                table: "Administrators",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administrators",
                table: "Administrators",
                column: "AdministratorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Administrators",
                table: "Administrators");

            migrationBuilder.AlterColumn<int>(
                name: "AdministratorId",
                table: "Administrators",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Administrators",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administrators",
                table: "Administrators",
                column: "Id");
        }
    }
}
