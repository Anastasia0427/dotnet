using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Planner.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    RoleDescription = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleName);
                });

            migrationBuilder.CreateTable(
                name: "Urgency",
                columns: table => new
                {
                    Urgency = table.Column<string>(type: "text", nullable: false),
                    UrgencyColor = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urgency", x => x.Urgency);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserInfo_Roles_Role",
                        column: x => x.Role,
                        principalTable: "Roles",
                        principalColumn: "RoleName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardInfo",
                columns: table => new
                {
                    BoardId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FKUserId = table.Column<int>(type: "integer", nullable: false),
                    BoardTitle = table.Column<string>(type: "text", nullable: false),
                    BoardDescription = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardInfo", x => x.BoardId);
                    table.ForeignKey(
                        name: "FK_BoardInfo_UserInfo_FKUserId",
                        column: x => x.FKUserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColumnInfo",
                columns: table => new
                {
                    ColumnId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FKUserId = table.Column<int>(type: "integer", nullable: false),
                    FKBoardId = table.Column<int>(type: "integer", nullable: false),
                    ColumnTitle = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnInfo", x => x.ColumnId);
                    table.ForeignKey(
                        name: "FK_ColumnInfo_BoardInfo_FKBoardId",
                        column: x => x.FKBoardId,
                        principalTable: "BoardInfo",
                        principalColumn: "BoardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnInfo_UserInfo_FKUserId",
                        column: x => x.FKUserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskInfo",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FKColumnId = table.Column<int>(type: "integer", nullable: false),
                    TaskTitle = table.Column<string>(type: "text", nullable: false),
                    TaskComplexity = table.Column<string>(type: "text", nullable: false),
                    TaskDeadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TaskUrgency = table.Column<string>(type: "text", nullable: true),
                    TaskProgress = table.Column<string>(type: "text", nullable: true),
                    TaskDescription = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskInfo", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_TaskInfo_ColumnInfo_FKColumnId",
                        column: x => x.FKColumnId,
                        principalTable: "ColumnInfo",
                        principalColumn: "ColumnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskInfo_Urgency_TaskUrgency",
                        column: x => x.TaskUrgency,
                        principalTable: "Urgency",
                        principalColumn: "Urgency");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardInfo_BoardTitle",
                table: "BoardInfo",
                column: "BoardTitle");

            migrationBuilder.CreateIndex(
                name: "IX_BoardInfo_FKUserId",
                table: "BoardInfo",
                column: "FKUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnInfo_ColumnTitle",
                table: "ColumnInfo",
                column: "ColumnTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColumnInfo_FKBoardId",
                table: "ColumnInfo",
                column: "FKBoardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColumnInfo_FKUserId",
                table: "ColumnInfo",
                column: "FKUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInfo_FKColumnId",
                table: "TaskInfo",
                column: "FKColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInfo_TaskTitle",
                table: "TaskInfo",
                column: "TaskTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskInfo_TaskUrgency",
                table: "TaskInfo",
                column: "TaskUrgency");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_Email",
                table: "UserInfo",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_Role",
                table: "UserInfo",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_UserName",
                table: "UserInfo",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskInfo");

            migrationBuilder.DropTable(
                name: "ColumnInfo");

            migrationBuilder.DropTable(
                name: "Urgency");

            migrationBuilder.DropTable(
                name: "BoardInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
