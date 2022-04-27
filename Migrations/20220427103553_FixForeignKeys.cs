using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.Migrations
{
    public partial class FixForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeDTOID",
                table: "PhoneNumbers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDTOID",
                table: "Emails",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_EmployeeDTOID",
                table: "PhoneNumbers",
                column: "EmployeeDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EmployeeDTOID",
                table: "Emails",
                column: "EmployeeDTOID");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Employees_EmployeeDTOID",
                table: "Emails",
                column: "EmployeeDTOID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_Employees_EmployeeDTOID",
                table: "PhoneNumbers",
                column: "EmployeeDTOID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Employees_EmployeeDTOID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_Employees_EmployeeDTOID",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_EmployeeDTOID",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Emails_EmployeeDTOID",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "EmployeeDTOID",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "EmployeeDTOID",
                table: "Emails");
        }
    }
}
