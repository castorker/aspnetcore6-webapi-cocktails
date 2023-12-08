using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orga.Idp.Migrations
{
    public partial class InitialOrgaIdentityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Password", "Subject", "UserName" },
                values: new object[] { new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), true, "41225e1b-7e2c-422c-9802-5b7235dd8e00", "password", "bcc4c51b-d20b-41dc-8152-cc7ed69c62c7", "Linda" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Password", "Subject", "UserName" },
                values: new object[] { new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), true, "1fc56e00-19ad-4bc8-897f-edb7d8cb11e9", "password", "ac46ef56-2155-4d0b-afd0-d10c5e7c89b1", "Johnny" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("5ae9db07-cc14-4aa1-8fa7-cb2e005f9cda"), "df460755-d997-4b0b-9cf2-795cf8c5d6a3", "family_name", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "Oldman" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("62f94c21-cd54-40f3-90d2-fd6f2f3eb8a6"), "91812d33-fae6-477d-aad7-2e2ec6d16bfa", "country", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "nl" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("6542efbb-69f2-44c1-aded-765465c5b299"), "171fed9f-03a5-4518-9942-09cc124a659e", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "11/06/2003" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("71e60714-ba0e-4141-92e7-122c072e642a"), "e0188b37-4f8e-425c-a073-4c1f1845d28f", "role", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "user" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("a5e38906-fafd-447d-9698-901bb24e553c"), "afec1637-cc38-459f-b3a0-aed4c18ca1a4", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "11/06/2013" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("b2e5b090-fe25-4a70-a859-9c05307489d2"), "36e6626d-361f-4932-ba1a-fd1d8a0841cc", "role", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "admin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("bc6ff57c-c7ad-425f-84b6-910bbb79a3db"), "2bc1110b-f20b-41c6-81fc-d264c6225b80", "given_name", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "Linda" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("bc907271-ac82-4741-897f-96797a85babb"), "85c83c6e-6255-4d14-988b-e7f80aec1d64", "country", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "pt" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("cf7c091d-dd51-4399-a33d-87aed849811c"), "5e081466-3c87-4a29-bafe-1e349fc600c3", "family_name", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "Young" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("e3f15ca2-6911-43ae-a33a-51252d4c32b1"), "da4a1e94-b9a3-43f3-9917-7a138426449d", "given_name", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "Johnny" });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subject",
                table: "Users",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
