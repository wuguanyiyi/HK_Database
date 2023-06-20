using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HK_Database.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APIKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    DataId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.DataId);
                    table.ForeignKey(
                        name: "FK_Datas_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Embedding",
                columns: table => new
                {
                    Index = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmbeddingQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmbeddingAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmbeddingVectors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embedding", x => x.Index);
                    table.ForeignKey(
                        name: "FK_Embedding_Datas_DataId",
                        column: x => x.DataId,
                        principalTable: "Datas",
                        principalColumn: "DataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChatData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QAHistory",
                columns: table => new
                {
                    QAHistoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QAHistoryQ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QAHistoryA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QAHistoryVectors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QAHistory", x => x.QAHistoryId);
                    table.ForeignKey(
                        name: "FK_QAHistory_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "MemberId", "APIKey", "MemberAccount", "MemberEmail", "MemberName", "MemberPassword", "MemberPhone" },
                values: new object[] { "C001", "aa", "althea", "althea@gmail.com", "Althea", "althea01", "0912345678" });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "MemberId", "APIKey", "MemberAccount", "MemberEmail", "MemberName", "MemberPassword", "MemberPhone" },
                values: new object[] { "C002", "aa", "jimmy", "jimmy@gmail.com", "Jimmy", "jimmy02", "0944332211" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationId", "MemberId", "Model" },
                values: new object[] { "A001", "C001", "mm" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationId", "MemberId", "Model" },
                values: new object[] { "A002", "C002", "mm" });

            migrationBuilder.InsertData(
                table: "Datas",
                columns: new[] { "DataId", "ApplicationId", "DataPath", "DataType" },
                values: new object[] { "D001", "A001", "dd", "dd" });

            migrationBuilder.InsertData(
                table: "Datas",
                columns: new[] { "DataId", "ApplicationId", "DataPath", "DataType" },
                values: new object[] { "D002", "A002", "dd", "dd" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ApplicationId", "UserAccount", "UserEmail", "UserName", "UserPassword", "UserPhone" },
                values: new object[] { "U001", "A001", "candy", "candy@gmail.com", "Candy", "candy03", "0987654654" });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ChatId", "ChatData", "ChatName", "UserId" },
                values: new object[] { "C001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(13), "Gay", "U001" });

            migrationBuilder.InsertData(
                table: "Embedding",
                columns: new[] { "Index", "DataId", "EmbeddingAnswer", "EmbeddingQuestion", "EmbeddingVectors", "QA" },
                values: new object[] { "ii", "D001", "ee", "ee", "ee", "qq" });

            migrationBuilder.InsertData(
                table: "QAHistory",
                columns: new[] { "QAHistoryId", "ChatId", "QAHistoryA", "QAHistoryQ", "QAHistoryVectors" },
                values: new object[] { "Q001", "C001", "qq", "qq", "qq" });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_MemberId",
                table: "Applications",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserId",
                table: "Chats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Datas_ApplicationId",
                table: "Datas",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Embedding_DataId",
                table: "Embedding",
                column: "DataId");

            migrationBuilder.CreateIndex(
                name: "IX_QAHistory_ChatId",
                table: "QAHistory",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApplicationId",
                table: "Users",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Embedding");

            migrationBuilder.DropTable(
                name: "QAHistory");

            migrationBuilder.DropTable(
                name: "Datas");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
