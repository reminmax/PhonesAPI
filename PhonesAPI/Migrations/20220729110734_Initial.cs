using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhonesAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Makers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModelName = table.Column<string>(maxLength: 100, nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    MakerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Makers_MakerId",
                        column: x => x.MakerId,
                        principalTable: "Makers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Makers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("510817aa-ea40-4135-8718-ed34adb5601c"), "Samsung" },
                    { new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"), "Sony" },
                    { new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"), "Apple" },
                    { new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"), "LG" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "MakerId", "ModelName", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("57a91ee1-018e-4c41-862c-7776c1885291"), new Guid("510817aa-ea40-4135-8718-ed34adb5601c"), "Galaxy M13", new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb98e5ff-39e3-405b-b32a-8fd12e158095"), new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"), "Q52", new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bc8a739e-a165-42bb-a3ee-db137f453223"), new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"), "W31+", new DateTime(2020, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5fc7a7f-2df5-4be4-81d8-3e40e3ab9192"), new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"), "W41 Pro", new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d29c31e5-e022-46f6-8a05-c534b733ea4b"), new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"), "iPhone 12", new DateTime(2020, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e4c6e94c-b362-4da2-b248-50fffd00fac0"), new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"), "iPhone 12 Pro", new DateTime(2020, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("52c19a0b-61b0-4df7-afac-668a30f82de7"), new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"), "iPhone 13 mini", new DateTime(2021, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9c013095-97c8-408b-8ce8-604526fe1363"), new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"), "iPhone 13 Pro Max", new DateTime(2021, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa063426-2fe5-4242-866f-baff3c94984c"), new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"), "iPhone SE (2022)", new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("79429c6e-41af-4b1d-b9dc-9d7cf72e952b"), new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"), "Xperia XZ1", new DateTime(2017, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8df2a05c-5270-42ed-8ad6-c7d0d15035e4"), new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"), "Sony Xperia L4", new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c79f3ab-0f33-4aba-a917-fdb030caea61"), new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"), "Xperia L3", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e9a8089-3952-42e7-a4f1-601461ce153e"), new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"), "Xperia Pro", new DateTime(2021, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("12321e5b-3c6c-408e-a06f-f026c858e349"), new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"), "Xperia 1 IV", new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c65d68b9-2f68-40a5-a34e-76f49e26d977"), new Guid("510817aa-ea40-4135-8718-ed34adb5601c"), "Galaxy Xcover 5", new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db29fd8a-b5b3-4cb5-b26c-7a2ad8d4732d"), new Guid("510817aa-ea40-4135-8718-ed34adb5601c"), "Galaxy M32", new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("47c33990-5133-4a29-ae8b-ee50c4acb042"), new Guid("510817aa-ea40-4135-8718-ed34adb5601c"), "Galaxy M52", new DateTime(2021, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a7c651d-834c-4496-afff-87b11b219d77"), new Guid("510817aa-ea40-4135-8718-ed34adb5601c"), "Galaxy M53", new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1065b60-86b6-4b11-8b59-642d297cfd86"), new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"), "Wing 5G", new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4279d25c-9e9d-43c9-bacc-9fe0ff1abc98"), new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"), "Stylo 6", new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_MakerId",
                table: "Phones",
                column: "MakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Makers");
        }
    }
}
