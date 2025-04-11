using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingProject.Migrations
{
    /// <inheritdoc />
    public partial class FixedCascadeIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbVote",
                columns: table => new
                {
                    VoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoteName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VoteDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbVote", x => x.VoteId);
                });

            migrationBuilder.CreateTable(
                name: "TbVoteOption",
                columns: table => new
                {
                    VoteOptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbVoteOption", x => x.VoteOptionId);
                    table.ForeignKey(
                        name: "FK_TbVoteOption_TbVote_VoteId",
                        column: x => x.VoteId,
                        principalTable: "TbVote",
                        principalColumn: "VoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbVoteResult",
                columns: table => new
                {
                    VoterResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PersonJob = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PersonExperence = table.Column<int>(type: "int", nullable: false),
                    PersonNote = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VoteId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbVoteResult", x => x.VoterResultId);
                    table.ForeignKey(
                        name: "FK_TbVoteResult_TbVoteOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "TbVoteOption",
                        principalColumn: "VoteOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbVoteResult_TbVote_VoteId",
                        column: x => x.VoteId,
                        principalTable: "TbVote",
                        principalColumn: "VoteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbVoteOption_VoteId",
                table: "TbVoteOption",
                column: "VoteId");

            migrationBuilder.CreateIndex(
                name: "IX_TbVoteResult_OptionId",
                table: "TbVoteResult",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TbVoteResult_VoteId",
                table: "TbVoteResult",
                column: "VoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbVoteResult");

            migrationBuilder.DropTable(
                name: "TbVoteOption");

            migrationBuilder.DropTable(
                name: "TbVote");
        }
    }
}
