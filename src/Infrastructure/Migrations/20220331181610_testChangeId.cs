using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class testChangeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpenIssueId",
                table: "OpenIssues",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IssueInReviewId",
                table: "IssuesInReview",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InProgressIssueId",
                table: "InProgressIssues",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClosedIssueId",
                table: "ClosedIssues",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OpenIssues",
                newName: "OpenIssueId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "IssuesInReview",
                newName: "IssueInReviewId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InProgressIssues",
                newName: "InProgressIssueId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ClosedIssues",
                newName: "ClosedIssueId");
        }
    }
}
