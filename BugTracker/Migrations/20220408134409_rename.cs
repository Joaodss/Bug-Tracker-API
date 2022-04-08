using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Companies_CompanyId",
                schema: "BugTracker",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Tickets_TicketId",
                schema: "BugTracker",
                table: "TicketComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Users_UserId",
                schema: "BugTracker",
                table: "TicketComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_ProjectId",
                schema: "BugTracker",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "BugTracker",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                schema: "BugTracker",
                table: "Users",
                newName: "role_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                schema: "BugTracker",
                table: "Users",
                newName: "IX_Users_role_id");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                schema: "BugTracker",
                table: "Tickets",
                newName: "project_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ProjectId",
                schema: "BugTracker",
                table: "Tickets",
                newName: "IX_Tickets_project_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "BugTracker",
                table: "TicketComments",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                schema: "BugTracker",
                table: "TicketComments",
                newName: "ticket_id");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComments_UserId",
                schema: "BugTracker",
                table: "TicketComments",
                newName: "IX_TicketComments_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComments_TicketId",
                schema: "BugTracker",
                table: "TicketComments",
                newName: "IX_TicketComments_ticket_id");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                schema: "BugTracker",
                table: "Projects",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_CompanyId",
                schema: "BugTracker",
                table: "Projects",
                newName: "IX_Projects_company_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Companies_company_id",
                schema: "BugTracker",
                table: "Projects",
                column: "company_id",
                principalSchema: "BugTracker",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Tickets_ticket_id",
                schema: "BugTracker",
                table: "TicketComments",
                column: "ticket_id",
                principalSchema: "BugTracker",
                principalTable: "Tickets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Users_user_id",
                schema: "BugTracker",
                table: "TicketComments",
                column: "user_id",
                principalSchema: "BugTracker",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_project_id",
                schema: "BugTracker",
                table: "Tickets",
                column: "project_id",
                principalSchema: "BugTracker",
                principalTable: "Projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_role_id",
                schema: "BugTracker",
                table: "Users",
                column: "role_id",
                principalSchema: "BugTracker",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Companies_company_id",
                schema: "BugTracker",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Tickets_ticket_id",
                schema: "BugTracker",
                table: "TicketComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Users_user_id",
                schema: "BugTracker",
                table: "TicketComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_project_id",
                schema: "BugTracker",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_role_id",
                schema: "BugTracker",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "role_id",
                schema: "BugTracker",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_role_id",
                schema: "BugTracker",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameColumn(
                name: "project_id",
                schema: "BugTracker",
                table: "Tickets",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_project_id",
                schema: "BugTracker",
                table: "Tickets",
                newName: "IX_Tickets_ProjectId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "BugTracker",
                table: "TicketComments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ticket_id",
                schema: "BugTracker",
                table: "TicketComments",
                newName: "TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComments_user_id",
                schema: "BugTracker",
                table: "TicketComments",
                newName: "IX_TicketComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketComments_ticket_id",
                schema: "BugTracker",
                table: "TicketComments",
                newName: "IX_TicketComments_TicketId");

            migrationBuilder.RenameColumn(
                name: "company_id",
                schema: "BugTracker",
                table: "Projects",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_company_id",
                schema: "BugTracker",
                table: "Projects",
                newName: "IX_Projects_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Companies_CompanyId",
                schema: "BugTracker",
                table: "Projects",
                column: "CompanyId",
                principalSchema: "BugTracker",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Tickets_TicketId",
                schema: "BugTracker",
                table: "TicketComments",
                column: "TicketId",
                principalSchema: "BugTracker",
                principalTable: "Tickets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Users_UserId",
                schema: "BugTracker",
                table: "TicketComments",
                column: "UserId",
                principalSchema: "BugTracker",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_ProjectId",
                schema: "BugTracker",
                table: "Tickets",
                column: "ProjectId",
                principalSchema: "BugTracker",
                principalTable: "Projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "BugTracker",
                table: "Users",
                column: "RoleId",
                principalSchema: "BugTracker",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
