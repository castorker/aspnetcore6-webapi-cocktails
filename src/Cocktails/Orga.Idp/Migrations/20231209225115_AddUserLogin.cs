using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orga.Idp.Migrations
{
    public partial class AddUserLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("00d32f88-cf06-4340-845a-276972f81cd7"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("06ef86e7-cb30-4526-b6dd-91e12f8d2ca4"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("120b1545-2924-4e2c-847c-245e3e0b72ce"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("374d3a51-d6b0-4e2e-8c0c-3736547129dc"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("862a4432-fc97-4906-b196-e78ad182dfbb"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ba178791-1854-46d0-a080-e939c2590954"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c8564347-1693-4a1c-8ee5-c199e3f418b6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d30d7e4c-f1dd-4db2-bc7e-85040f6d385e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("df799934-7dc9-4ce2-84af-b22b965c22ea"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f1ebf80b-a0f9-4ce8-b366-4ea102f17a14"));

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Provider = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ProviderIdentityKey = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins");

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

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("00d32f88-cf06-4340-845a-276972f81cd7"), "c6191d5a-e4b6-4f0e-9d5b-ba455c678b0c", "family_name", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "Young" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("06ef86e7-cb30-4526-b6dd-91e12f8d2ca4"), "c99bc5e6-242b-4b79-928d-0be372acb6f8", "family_name", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "Oldman" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("120b1545-2924-4e2c-847c-245e3e0b72ce"), "58516d6c-bfc8-4931-9613-9e071e02a6b4", "given_name", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "Johnny" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("374d3a51-d6b0-4e2e-8c0c-3736547129dc"), "4bf86fa3-7862-4c15-9ac4-d106605edf47", "role", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "user" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("862a4432-fc97-4906-b196-e78ad182dfbb"), "2768bc55-5606-47d9-a25c-348f36b91391", "given_name", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "Linda" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("ba178791-1854-46d0-a080-e939c2590954"), "2a353f3b-d2dc-4412-9410-b1d49da62d12", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "11/06/2003" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("c8564347-1693-4a1c-8ee5-c199e3f418b6"), "1a2cf360-85cf-4a60-b299-21b4df08b173", "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "11/06/2013" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("d30d7e4c-f1dd-4db2-bc7e-85040f6d385e"), "7b33c3a4-9bac-41a9-a127-aa6813c74674", "country", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "pt" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("df799934-7dc9-4ce2-84af-b22b965c22ea"), "02587504-6c2c-43ec-a1a1-d86edcfb2c8c", "country", new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"), "nl" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[] { new Guid("f1ebf80b-a0f9-4ce8-b366-4ea102f17a14"), "d5fe500c-620c-487b-a201-8187b6583cc0", "role", new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"), "admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                column: "ConcurrencyStamp",
                value: "ac92fb1f-037f-4af6-b0f1-abd38ba98bb8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                column: "ConcurrencyStamp",
                value: "c2e4f193-342d-4785-b527-df792c9fc9a6");
        }
    }
}
