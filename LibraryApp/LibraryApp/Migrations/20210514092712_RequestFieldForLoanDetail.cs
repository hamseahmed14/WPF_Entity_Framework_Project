using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp.Migrations
{
    public partial class RequestFieldForLoanDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Request",
                table: "LoanDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Request",
                table: "LoanDetails");
        }
    }
}
