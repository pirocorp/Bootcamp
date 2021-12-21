using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recrutment.Api.Migrations
{
    public partial class Interviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Candidates_CandidateId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Jobs_JobId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Recruiters_RecruiterId",
                table: "Interview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interview",
                table: "Interview");

            migrationBuilder.RenameTable(
                name: "Interview",
                newName: "Interviews");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_JobId",
                table: "Interviews",
                newName: "IX_Interviews_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_CandidateId",
                table: "Interviews",
                newName: "IX_Interviews_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews",
                columns: new[] { "RecruiterId", "JobId", "CandidateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Candidates_CandidateId",
                table: "Interviews",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Jobs_JobId",
                table: "Interviews",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Recruiters_RecruiterId",
                table: "Interviews",
                column: "RecruiterId",
                principalTable: "Recruiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Candidates_CandidateId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Jobs_JobId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Recruiters_RecruiterId",
                table: "Interviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews");

            migrationBuilder.RenameTable(
                name: "Interviews",
                newName: "Interview");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_JobId",
                table: "Interview",
                newName: "IX_Interview_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_CandidateId",
                table: "Interview",
                newName: "IX_Interview_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interview",
                table: "Interview",
                columns: new[] { "RecruiterId", "JobId", "CandidateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Candidates_CandidateId",
                table: "Interview",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Jobs_JobId",
                table: "Interview",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Recruiters_RecruiterId",
                table: "Interview",
                column: "RecruiterId",
                principalTable: "Recruiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
