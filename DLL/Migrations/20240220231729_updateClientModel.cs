using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance.DLL.Migrations
{
    /// <inheritdoc />
    public partial class updateClientModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientEmail",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Contracts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientPassportCode",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientPatronymic",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientPhone",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientSurname",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientEmail",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ClientPassportCode",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ClientPatronymic",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ClientPhone",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ClientSurname",
                table: "Contracts");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Contracts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
