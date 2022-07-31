using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhonesAPI.Migrations
{
    public partial class AddNewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RamGb",
                table: "Phones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("12321e5b-3c6c-408e-a06f-f026c858e349"),
                column: "RamGb",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("2e9a8089-3952-42e7-a4f1-601461ce153e"),
                column: "RamGb",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("4279d25c-9e9d-43c9-bacc-9fe0ff1abc98"),
                column: "RamGb",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("47c33990-5133-4a29-ae8b-ee50c4acb042"),
                column: "RamGb",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("4c79f3ab-0f33-4aba-a917-fdb030caea61"),
                column: "RamGb",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("52c19a0b-61b0-4df7-afac-668a30f82de7"),
                column: "RamGb",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("57a91ee1-018e-4c41-862c-7776c1885291"),
                column: "RamGb",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("79429c6e-41af-4b1d-b9dc-9d7cf72e952b"),
                column: "RamGb",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("7a7c651d-834c-4496-afff-87b11b219d77"),
                column: "RamGb",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("8df2a05c-5270-42ed-8ad6-c7d0d15035e4"),
                columns: new[] { "ModelName", "RamGb" },
                values: new object[] { "Xperia L4", 3 });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("9c013095-97c8-408b-8ce8-604526fe1363"),
                column: "RamGb",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("b1065b60-86b6-4b11-8b59-642d297cfd86"),
                column: "RamGb",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("bc8a739e-a165-42bb-a3ee-db137f453223"),
                column: "RamGb",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("c65d68b9-2f68-40a5-a34e-76f49e26d977"),
                column: "RamGb",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("d29c31e5-e022-46f6-8a05-c534b733ea4b"),
                column: "RamGb",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("db29fd8a-b5b3-4cb5-b26c-7a2ad8d4732d"),
                column: "RamGb",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("e4c6e94c-b362-4da2-b248-50fffd00fac0"),
                column: "RamGb",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("e5fc7a7f-2df5-4be4-81d8-3e40e3ab9192"),
                column: "RamGb",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("fa063426-2fe5-4242-866f-baff3c94984c"),
                column: "RamGb",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("fb98e5ff-39e3-405b-b32a-8fd12e158095"),
                column: "RamGb",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RamGb",
                table: "Phones");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("8df2a05c-5270-42ed-8ad6-c7d0d15035e4"),
                column: "ModelName",
                value: "Sony Xperia L4");
        }
    }
}
