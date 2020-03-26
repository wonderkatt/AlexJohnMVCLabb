using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodBowlTeamManager.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    RaceName = table.Column<string>(nullable: true),
                    RerollCost = table.Column<int>(nullable: false),
                    Apothecary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    RaceId = table.Column<string>(nullable: true),
                    CoachId = table.Column<string>(nullable: true),
                    TeamName = table.Column<string>(nullable: true),
                    Teamvalue = table.Column<int>(nullable: false),
                    NumberOfReRolls = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teams_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    isAvailable = table.Column<bool>(nullable: false),
                    RaceId = table.Column<string>(nullable: true),
                    TeamId = table.Column<string>(nullable: true),
                    PlayerName = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    Touchdowns = table.Column<int>(nullable: false),
                    Casualties = table.Column<int>(nullable: false),
                    Completions = table.Column<int>(nullable: false),
                    Interceptions = table.Column<int>(nullable: false),
                    MVP = table.Column<int>(nullable: false),
                    SPP = table.Column<int>(nullable: false),
                    MissNextGame = table.Column<bool>(nullable: false),
                    MovementValue = table.Column<int>(nullable: false),
                    StrengthValue = table.Column<int>(nullable: false),
                    AgilityValue = table.Column<int>(nullable: false),
                    ArmourValue = table.Column<int>(nullable: false),
                    PlayedGames = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.id);
                    table.ForeignKey(
                        name: "FK_Players_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgilitySkills",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    AgiSkill = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgilitySkills", x => x.id);
                    table.ForeignKey(
                        name: "FK_AgilitySkills_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSkills",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    GenSkill = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSkills", x => x.id);
                    table.ForeignKey(
                        name: "FK_GeneralSkills_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mutations",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    MutationSkill = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mutations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mutations_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PassSkills",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    pasSkill = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassSkills", x => x.id);
                    table.ForeignKey(
                        name: "FK_PassSkills_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialSkill",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    SpecSkill = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialSkill", x => x.id);
                    table.ForeignKey(
                        name: "FK_SpecialSkill_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StrengthSkills",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    StrSkill = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrengthSkills", x => x.id);
                    table.ForeignKey(
                        name: "FK_StrengthSkills_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgilitySkills_PlayerId",
                table: "AgilitySkills",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSkills_PlayerId",
                table: "GeneralSkills",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Mutations_PlayerId",
                table: "Mutations",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PassSkills_PlayerId",
                table: "PassSkills",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_RaceId",
                table: "Players",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialSkill_PlayerId",
                table: "SpecialSkill",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_StrengthSkills_PlayerId",
                table: "StrengthSkills",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachId",
                table: "Teams",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_RaceId",
                table: "Teams",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgilitySkills");

            migrationBuilder.DropTable(
                name: "GeneralSkills");

            migrationBuilder.DropTable(
                name: "Mutations");

            migrationBuilder.DropTable(
                name: "PassSkills");

            migrationBuilder.DropTable(
                name: "SpecialSkill");

            migrationBuilder.DropTable(
                name: "StrengthSkills");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
