using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orga.Idp.Migrations
{
    public partial class AddAccountActivation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("5ae9db07-cc14-4aa1-8fa7-cb2e005f9cda"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("62f94c21-cd54-40f3-90d2-fd6f2f3eb8a6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6542efbb-69f2-44c1-aded-765465c5b299"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("71e60714-ba0e-4141-92e7-122c072e642a"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a5e38906-fafd-447d-9698-901bb24e553c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b2e5b090-fe25-4a70-a859-9c05307489d2"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("bc6ff57c-c7ad-425f-84b6-910bbb79a3db"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("bc907271-ac82-4741-897f-96797a85babb"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("cf7c091d-dd51-4399-a33d-87aed849811c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e3f15ca2-6911-43ae-a33a-51252d4c32b1"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecurityCodeExpirationDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                columns: new[] { "ConcurrencyStamp", "Email" },
                values: new object[] { "ac92fb1f-037f-4af6-b0f1-abd38ba98bb8", "linda@emailprovider.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                columns: new[] { "ConcurrencyStamp", "Email" },
                values: new object[] { "c2e4f193-342d-4785-b527-df792c9fc9a6", "johnny@emailprovider.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCodeExpirationDate",
                table: "Users");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                column: "ConcurrencyStamp",
                value: "41225e1b-7e2c-422c-9802-5b7235dd8e00");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                column: "ConcurrencyStamp",
                value: "1fc56e00-19ad-4bc8-897f-edb7d8cb11e9");
        }
    }
}
