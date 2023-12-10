using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orga.Idp.Migrations
{
    public partial class AddUserSecret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("1459a0f4-7de9-4155-9ffa-cc695cd54abe"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3f05c5e9-9712-4705-bb2c-5acc043b799f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("4e2404c2-ca3d-4f4a-9613-913ac8e36268"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("50e08f99-feeb-4d06-b129-04d404e31919"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("5368e843-0250-41d3-b45e-64b7fbc83c30"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("5db08309-f4ad-4f09-a9f4-3e907870e5c8"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("7d5eb2d3-5fea-44de-acb1-b9679f2e77d9"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a68ac04e-0a53-4347-bbd3-f43980787750"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c2ea18fe-f7a7-479b-ab82-8ed68a527ce2"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("eb133b25-e0cb-4c49-9cb1-3306aa0eb08e"));

            migrationBuilder.CreateTable(
                name: "UserSecrets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Secret = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSecrets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("13640081-654d-4ddb-8f95-5df64c2de579"), "1b8b4606-3eb6-492b-94a9-ee8d1c1472e7", "role", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "user" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("16ac1be5-ecb4-4622-88fd-60d112a0a2b4"), "8559dd5a-be33-4981-a5e1-9c191f1d0885", "country", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "pt" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("229c4bb7-0cbf-44ab-aaf8-2684fb1f1fa1"), "70787a21-39f6-442b-b235-389ae0490da2", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "11/06/2003" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("4731b610-8d53-4897-ad72-52d579124686"), "582b95a8-e755-4576-b7e4-6f43aa4bf26b", "family_name", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "Young" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("4ba21ec6-d596-4436-b3b6-73f952728350"), "6c248649-9ec7-4b79-abd2-a671b47bb9f2", "country", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "nl" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("6692e4e8-af0d-40a7-8a6e-8c74bf0beb5f"), "0d44645a-746d-443b-b935-159def43275c", "given_name", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "Linda" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("77ad9808-d3f3-42ae-a70c-57288109e94e"), "e845f2b3-d433-42e8-8a38-5dac9c6055c8", "family_name", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "Oldman" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("d10c2a4a-e4d4-49da-8cd6-2f167be94ca6"), "fcf44fa5-11b1-45c3-897a-94573397c7a5", "role", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "admin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("efb0efce-6eb9-4a57-bfff-fa2f150ca952"), "01a4564b-9729-4d10-b9cb-835e8bc193d3", "given_name", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "Johnny" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("efeedd6a-047d-4cca-aa76-4830d0635bf0"), "24c3f630-0047-4907-b13d-e007c11b30d5", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "11/06/2013" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                column: "ConcurrencyStamp",
                value: "6456542b-527e-4939-97a4-4921bc4171ea");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                column: "ConcurrencyStamp",
                value: "c45762ac-c9d8-4942-aecb-b020412f077a");

            migrationBuilder.CreateIndex(
                name: "IX_UserSecrets_UserId",
                table: "UserSecrets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSecrets");

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("13640081-654d-4ddb-8f95-5df64c2de579"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("16ac1be5-ecb4-4622-88fd-60d112a0a2b4"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("229c4bb7-0cbf-44ab-aaf8-2684fb1f1fa1"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("4731b610-8d53-4897-ad72-52d579124686"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("4ba21ec6-d596-4436-b3b6-73f952728350"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6692e4e8-af0d-40a7-8a6e-8c74bf0beb5f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("77ad9808-d3f3-42ae-a70c-57288109e94e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d10c2a4a-e4d4-49da-8cd6-2f167be94ca6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("efb0efce-6eb9-4a57-bfff-fa2f150ca952"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("efeedd6a-047d-4cca-aa76-4830d0635bf0"));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("1459a0f4-7de9-4155-9ffa-cc695cd54abe"), "d50e2d26-9e46-4645-ab4b-0456af1a338f", "country", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "pt" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("3f05c5e9-9712-4705-bb2c-5acc043b799f"), "17596e1c-83c5-43cf-b245-df7f1e82fd4c", "family_name", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "Young" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("4e2404c2-ca3d-4f4a-9613-913ac8e36268"), "994f67f5-37e5-4d5b-bcfb-179f578d3247", "given_name", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "Linda" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("50e08f99-feeb-4d06-b129-04d404e31919"), "0e873c3e-04a3-4c64-adfd-35660593b596", "role", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "user" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("5368e843-0250-41d3-b45e-64b7fbc83c30"), "bd583cb8-69a9-406c-932c-7edcbee09639", "family_name", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "Oldman" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("5db08309-f4ad-4f09-a9f4-3e907870e5c8"), "84189f76-f241-425f-8e87-c4a816c6958d", "country", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "nl" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("7d5eb2d3-5fea-44de-acb1-b9679f2e77d9"), "519a3367-92c5-40a2-9851-ba08ae607e65", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "11/06/2003" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("a68ac04e-0a53-4347-bbd3-f43980787750"), "c64ad401-35bf-4dfc-9975-eea487a1c749", "role", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "admin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("c2ea18fe-f7a7-479b-ab82-8ed68a527ce2"), "b5f8dfa7-e9dd-4772-b4f9-70d87118dd40", "given_name", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "Johnny" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("eb133b25-e0cb-4c49-9cb1-3306aa0eb08e"), "b82f46a2-416a-4efa-a11a-7331ec11d9ca", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "11/06/2013" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                column: "ConcurrencyStamp",
                value: "4dcd8f2c-5399-465b-8a6f-671f4ca47a75");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                column: "ConcurrencyStamp",
                value: "cbbddc73-a66a-4817-a171-b918772d6e68");
        }
    }
}
