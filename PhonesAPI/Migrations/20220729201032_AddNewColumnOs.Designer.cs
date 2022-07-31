﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhonesAPI.DbContexts;

namespace PhonesAPI.Migrations
{
    [DbContext(typeof(MakerPhoneContext))]
    [Migration("20220729201032_AddNewColumnOs")]
    partial class AddNewColumnOs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhonesAPI.Entities.Maker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Makers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("510817aa-ea40-4135-8718-ed34adb5601c"),
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"),
                            Name = "Sony"
                        },
                        new
                        {
                            Id = new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"),
                            Name = "Apple"
                        },
                        new
                        {
                            Id = new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"),
                            Name = "LG"
                        });
                });

            modelBuilder.Entity("PhonesAPI.Entities.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MakerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RamGb")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MakerId");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            Id = new Guid("57a91ee1-018e-4c41-862c-7776c1885291"),
                            MakerId = new Guid("510817aa-ea40-4135-8718-ed34adb5601c"),
                            ModelName = "Galaxy M13",
                            OS = "Android 12",
                            RamGb = 6,
                            ReleaseDate = new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("7a7c651d-834c-4496-afff-87b11b219d77"),
                            MakerId = new Guid("510817aa-ea40-4135-8718-ed34adb5601c"),
                            ModelName = "Galaxy M53",
                            OS = "Android 12",
                            RamGb = 8,
                            ReleaseDate = new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("47c33990-5133-4a29-ae8b-ee50c4acb042"),
                            MakerId = new Guid("510817aa-ea40-4135-8718-ed34adb5601c"),
                            ModelName = "Galaxy M52",
                            OS = "Android 11",
                            RamGb = 8,
                            ReleaseDate = new DateTime(2021, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("db29fd8a-b5b3-4cb5-b26c-7a2ad8d4732d"),
                            MakerId = new Guid("510817aa-ea40-4135-8718-ed34adb5601c"),
                            ModelName = "Galaxy M32",
                            OS = "Android 11",
                            RamGb = 4,
                            ReleaseDate = new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("c65d68b9-2f68-40a5-a34e-76f49e26d977"),
                            MakerId = new Guid("510817aa-ea40-4135-8718-ed34adb5601c"),
                            ModelName = "Galaxy Xcover 5",
                            OS = "Android 11",
                            RamGb = 4,
                            ReleaseDate = new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("12321e5b-3c6c-408e-a06f-f026c858e349"),
                            MakerId = new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"),
                            ModelName = "Xperia 1 IV",
                            OS = "Android 12",
                            RamGb = 12,
                            ReleaseDate = new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("2e9a8089-3952-42e7-a4f1-601461ce153e"),
                            MakerId = new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"),
                            ModelName = "Xperia Pro",
                            OS = "Android 10",
                            RamGb = 12,
                            ReleaseDate = new DateTime(2021, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("4c79f3ab-0f33-4aba-a917-fdb030caea61"),
                            MakerId = new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"),
                            ModelName = "Xperia L3",
                            OS = "Android 8",
                            RamGb = 3,
                            ReleaseDate = new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("8df2a05c-5270-42ed-8ad6-c7d0d15035e4"),
                            MakerId = new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"),
                            ModelName = "Xperia L4",
                            OS = "Android 9",
                            RamGb = 3,
                            ReleaseDate = new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("79429c6e-41af-4b1d-b9dc-9d7cf72e952b"),
                            MakerId = new Guid("71e948ef-2334-44e1-b04e-38a82bfebe4d"),
                            ModelName = "Xperia XZ1",
                            OS = "Android 8",
                            RamGb = 4,
                            ReleaseDate = new DateTime(2017, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("fa063426-2fe5-4242-866f-baff3c94984c"),
                            MakerId = new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"),
                            ModelName = "iPhone SE (2022)",
                            OS = "iOS 15.4",
                            RamGb = 4,
                            ReleaseDate = new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("9c013095-97c8-408b-8ce8-604526fe1363"),
                            MakerId = new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"),
                            ModelName = "iPhone 13 Pro Max",
                            OS = "iOS 15",
                            RamGb = 6,
                            ReleaseDate = new DateTime(2021, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("52c19a0b-61b0-4df7-afac-668a30f82de7"),
                            MakerId = new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"),
                            ModelName = "iPhone 13 mini",
                            OS = "iOS 15",
                            RamGb = 4,
                            ReleaseDate = new DateTime(2021, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e4c6e94c-b362-4da2-b248-50fffd00fac0"),
                            MakerId = new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"),
                            ModelName = "iPhone 12 Pro",
                            OS = "iOS 14.1",
                            RamGb = 6,
                            ReleaseDate = new DateTime(2020, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("d29c31e5-e022-46f6-8a05-c534b733ea4b"),
                            MakerId = new Guid("1ad4c61a-e483-4730-bfd9-697a910f8601"),
                            ModelName = "iPhone 12",
                            OS = "iOS 14.1",
                            RamGb = 4,
                            ReleaseDate = new DateTime(2020, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e5fc7a7f-2df5-4be4-81d8-3e40e3ab9192"),
                            MakerId = new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"),
                            ModelName = "W41 Pro",
                            OS = "Android 10",
                            RamGb = 6,
                            ReleaseDate = new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("bc8a739e-a165-42bb-a3ee-db137f453223"),
                            MakerId = new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"),
                            ModelName = "W31+",
                            OS = "Android 10",
                            RamGb = 4,
                            ReleaseDate = new DateTime(2020, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("fb98e5ff-39e3-405b-b32a-8fd12e158095"),
                            MakerId = new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"),
                            ModelName = "Q52",
                            OS = "Android 10",
                            RamGb = 4,
                            ReleaseDate = new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("b1065b60-86b6-4b11-8b59-642d297cfd86"),
                            MakerId = new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"),
                            ModelName = "Wing 5G",
                            OS = "Android 10",
                            RamGb = 8,
                            ReleaseDate = new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("4279d25c-9e9d-43c9-bacc-9fe0ff1abc98"),
                            MakerId = new Guid("e3f51f68-af51-449a-ad85-89ee6ee8be5b"),
                            ModelName = "Stylo 6",
                            OS = "Android 10",
                            RamGb = 3,
                            ReleaseDate = new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PhonesAPI.Entities.Phone", b =>
                {
                    b.HasOne("PhonesAPI.Entities.Maker", "Maker")
                        .WithMany("Phones")
                        .HasForeignKey("MakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
