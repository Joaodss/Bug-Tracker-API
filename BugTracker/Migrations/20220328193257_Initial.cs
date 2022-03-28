using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BugTracker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BugTracker");

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "BugTracker",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "BugTracker",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "BugTracker",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.id);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "BugTracker",
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "BugTracker",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    photo_url = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "BugTracker",
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "BugTracker",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tickets_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "BugTracker",
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedUsersCompanies",
                schema: "BugTracker",
                columns: table => new
                {
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedUsersCompanies", x => new { x.CompanyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AssignedUsersCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "BugTracker",
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedUsersCompanies_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "BugTracker",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedUsersProjects",
                schema: "BugTracker",
                columns: table => new
                {
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedUsersProjects", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AssignedUsersProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "BugTracker",
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedUsersProjects_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "BugTracker",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnedUsersCompanies",
                schema: "BugTracker",
                columns: table => new
                {
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedUsersCompanies", x => new { x.CompanyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_OwnedUsersCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "BugTracker",
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedUsersCompanies_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "BugTracker",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnedUsersProjects",
                schema: "BugTracker",
                columns: table => new
                {
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedUsersProjects", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_OwnedUsersProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "BugTracker",
                        principalTable: "Projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedUsersProjects_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "BugTracker",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedUsersTickets",
                schema: "BugTracker",
                columns: table => new
                {
                    TicketId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedUsersTickets", x => new { x.TicketId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AssignedUsersTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "BugTracker",
                        principalTable: "Tickets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedUsersTickets_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "BugTracker",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnedUsersTickets",
                schema: "BugTracker",
                columns: table => new
                {
                    TicketId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedUsersTickets", x => new { x.TicketId, x.UserId });
                    table.ForeignKey(
                        name: "FK_OwnedUsersTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "BugTracker",
                        principalTable: "Tickets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedUsersTickets_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "BugTracker",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketComments",
                schema: "BugTracker",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    content = table.Column<string>(type: "text", nullable: false),
                    TicketId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketComments", x => x.id);
                    table.ForeignKey(
                        name: "FK_TicketComments_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "BugTracker",
                        principalTable: "Tickets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketComments_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "BugTracker",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedUsersCompanies_UserId",
                schema: "BugTracker",
                table: "AssignedUsersCompanies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedUsersProjects_UserId",
                schema: "BugTracker",
                table: "AssignedUsersProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedUsersTickets_UserId",
                schema: "BugTracker",
                table: "AssignedUsersTickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedUsersCompanies_UserId",
                schema: "BugTracker",
                table: "OwnedUsersCompanies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedUsersProjects_UserId",
                schema: "BugTracker",
                table: "OwnedUsersProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedUsersTickets_UserId",
                schema: "BugTracker",
                table: "OwnedUsersTickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyId",
                schema: "BugTracker",
                table: "Projects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketComments_TicketId",
                schema: "BugTracker",
                table: "TicketComments",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketComments_UserId",
                schema: "BugTracker",
                table: "TicketComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectId",
                schema: "BugTracker",
                table: "Tickets",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "BugTracker",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedUsersCompanies",
                schema: "BugTracker");

            migrationBuilder.DropTable(
                name: "AssignedUsersProjects",
                schema: "BugTracker");

            migrationBuilder.DropTable(
                name: "AssignedUsersTickets",
                schema: "BugTracker");

            migrationBuilder.DropTable(
                name: "OwnedUsersCompanies",
                schema: "BugTracker");

            migrationBuilder.DropTable(
                name: "OwnedUsersProjects",
                schema: "BugTracker");

            migrationBuilder.DropTable(
                name: "OwnedUsersTickets",
                schema: "BugTracker");

            migrationBuilder.DropTable(
                name: "TicketComments",
                schema: "BugTracker");

            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "BugTracker");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "BugTracker");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "BugTracker");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "BugTracker");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "BugTracker");
        }
    }
}
