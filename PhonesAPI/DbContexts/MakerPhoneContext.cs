using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhonesAPI.Entities;

namespace PhonesAPI.DbContexts
{
    public class MakerPhoneContext: DbContext
    {
        public MakerPhoneContext(DbContextOptions<MakerPhoneContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Maker> Makers { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<LogEntry> Logger { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Maker>().HasData(
                new Maker
                {
                    Id = Guid.Parse("510817aa-ea40-4135-8718-ed34adb5601c"), 
                    Name = "Samsung"
                },
                new Maker
                {
                    Id = Guid.Parse("71e948ef-2334-44e1-b04e-38a82bfebe4d"), 
                    Name = "Sony" 
                },
                new Maker
                {
                    Id = Guid.Parse("1ad4c61a-e483-4730-bfd9-697a910f8601"), 
                    Name = "Apple" 
                },
                new Maker
                {
                    Id = Guid.Parse("e3f51f68-af51-449a-ad85-89ee6ee8be5b"), 
                    Name = "LG" 
                }
            );

            modelBuilder.Entity<Phone>().HasData(
                // Samsung
                new Phone
                {
                    Id = Guid.Parse("57a91ee1-018e-4c41-862c-7776c1885291"),
                    ModelName = "Galaxy M13",
                    ReleaseDate = new DateTime(2022, 7, 23),
                    RamGb = 6,
                    OS = "Android 12",
                    MakerId = Guid.Parse("510817aa-ea40-4135-8718-ed34adb5601c")
                },
                new Phone
                {
                    Id = Guid.Parse("7a7c651d-834c-4496-afff-87b11b219d77"),
                    ModelName = "Galaxy M53",
                    ReleaseDate = new DateTime(2022, 4, 7),
                    RamGb = 8,
                    OS = "Android 12",
                    MakerId = Guid.Parse("510817aa-ea40-4135-8718-ed34adb5601c")
                },
                new Phone
                {
                    Id = Guid.Parse("47c33990-5133-4a29-ae8b-ee50c4acb042"),
                    ModelName = "Galaxy M52",
                    ReleaseDate = new DateTime(2021, 10, 3),
                    RamGb = 8,
                    OS = "Android 11",
                    MakerId = Guid.Parse("510817aa-ea40-4135-8718-ed34adb5601c")
                },
                new Phone
                {
                    Id = Guid.Parse("db29fd8a-b5b3-4cb5-b26c-7a2ad8d4732d"),
                    ModelName = "Galaxy M32",
                    ReleaseDate = new DateTime(2021, 6, 28),
                    RamGb = 4,
                    OS = "Android 11",
                    MakerId = Guid.Parse("510817aa-ea40-4135-8718-ed34adb5601c")
                },
                new Phone
                {
                    Id = Guid.Parse("c65d68b9-2f68-40a5-a34e-76f49e26d977"),
                    ModelName = "Galaxy Xcover 5",
                    ReleaseDate = new DateTime(2021, 3, 12),
                    RamGb = 4,
                    OS = "Android 11",
                    MakerId = Guid.Parse("510817aa-ea40-4135-8718-ed34adb5601c")
                },

                // Sony
                new Phone
                {
                    Id = Guid.Parse("12321e5b-3c6c-408e-a06f-f026c858e349"),
                    ModelName = "Xperia 1 IV",
                    ReleaseDate = new DateTime(2022, 6, 11),
                    RamGb = 12,
                    OS = "Android 12",
                    MakerId = Guid.Parse("71e948ef-2334-44e1-b04e-38a82bfebe4d")
                },
                new Phone
                {
                    Id = Guid.Parse("2e9a8089-3952-42e7-a4f1-601461ce153e"),
                    ModelName = "Xperia Pro",
                    ReleaseDate = new DateTime(2021, 1, 27),
                    RamGb = 12,
                    OS = "Android 10",
                    MakerId = Guid.Parse("71e948ef-2334-44e1-b04e-38a82bfebe4d")
                },
                new Phone
                {
                    Id = Guid.Parse("4c79f3ab-0f33-4aba-a917-fdb030caea61"),
                    ModelName = "Xperia L3",
                    ReleaseDate = new DateTime(2019, 2, 1),
                    RamGb = 3,
                    OS = "Android 8",
                    MakerId = Guid.Parse("71e948ef-2334-44e1-b04e-38a82bfebe4d")
                },
                new Phone
                {
                    Id = Guid.Parse("8df2a05c-5270-42ed-8ad6-c7d0d15035e4"),
                    ModelName = "Xperia L4",
                    ReleaseDate = new DateTime(2020, 4, 28),
                    RamGb = 3,
                    OS = "Android 9",
                    MakerId = Guid.Parse("71e948ef-2334-44e1-b04e-38a82bfebe4d")
                },
                new Phone
                {
                    Id = Guid.Parse("79429c6e-41af-4b1d-b9dc-9d7cf72e952b"),
                    ModelName = "Xperia XZ1",
                    ReleaseDate = new DateTime(2017, 9, 19),
                    RamGb = 4,
                    OS = "Android 8",
                    MakerId = Guid.Parse("71e948ef-2334-44e1-b04e-38a82bfebe4d")
                },


                // Apple
                new Phone
                {
                    Id = Guid.Parse("fa063426-2fe5-4242-866f-baff3c94984c"),
                    ModelName = "iPhone SE (2022)",
                    ReleaseDate = new DateTime(2022, 3, 18),
                    RamGb = 4,
                    OS = "iOS 15.4",
                    MakerId = Guid.Parse("1ad4c61a-e483-4730-bfd9-697a910f8601")
                },
                new Phone
                {
                    Id = Guid.Parse("9c013095-97c8-408b-8ce8-604526fe1363"),
                    ModelName = "iPhone 13 Pro Max",
                    ReleaseDate = new DateTime(2021, 9, 24),
                    RamGb = 6,
                    OS = "iOS 15",
                    MakerId = Guid.Parse("1ad4c61a-e483-4730-bfd9-697a910f8601")
                },
                new Phone
                {
                    Id = Guid.Parse("52c19a0b-61b0-4df7-afac-668a30f82de7"),
                    ModelName = "iPhone 13 mini",
                    ReleaseDate = new DateTime(2021, 9, 24),
                    RamGb = 4,
                    OS = "iOS 15",
                    MakerId = Guid.Parse("1ad4c61a-e483-4730-bfd9-697a910f8601")
                },
                new Phone
                {
                    Id = Guid.Parse("e4c6e94c-b362-4da2-b248-50fffd00fac0"),
                    ModelName = "iPhone 12 Pro",
                    ReleaseDate = new DateTime(2020, 10, 23),
                    RamGb = 6,
                    OS = "iOS 14.1",
                    MakerId = Guid.Parse("1ad4c61a-e483-4730-bfd9-697a910f8601")
                },
                new Phone
                {
                    Id = Guid.Parse("d29c31e5-e022-46f6-8a05-c534b733ea4b"),
                    ModelName = "iPhone 12",
                    ReleaseDate = new DateTime(2020, 10, 23),
                    RamGb = 4,
                    OS = "iOS 14.1",
                    MakerId = Guid.Parse("1ad4c61a-e483-4730-bfd9-697a910f8601")
                },

                // LG
                new Phone
                {
                    Id = Guid.Parse("e5fc7a7f-2df5-4be4-81d8-3e40e3ab9192"),
                    ModelName = "W41 Pro",
                    ReleaseDate = new DateTime(2021, 3, 3),
                    RamGb = 6,
                    OS = "Android 10",
                    MakerId = Guid.Parse("e3f51f68-af51-449a-ad85-89ee6ee8be5b")
                },
                new Phone
                {
                    Id = Guid.Parse("bc8a739e-a165-42bb-a3ee-db137f453223"),
                    ModelName = "W31+",
                    ReleaseDate = new DateTime(2020, 12, 23),
                    RamGb = 4,
                    OS = "Android 10",
                    MakerId = Guid.Parse("e3f51f68-af51-449a-ad85-89ee6ee8be5b")
                },
                new Phone
                {
                    Id = Guid.Parse("fb98e5ff-39e3-405b-b32a-8fd12e158095"),
                    ModelName = "Q52",
                    ReleaseDate = new DateTime(2020, 10, 26),
                    RamGb = 4,
                    OS = "Android 10",
                    MakerId = Guid.Parse("e3f51f68-af51-449a-ad85-89ee6ee8be5b")
                },
                new Phone
                {
                    Id = Guid.Parse("b1065b60-86b6-4b11-8b59-642d297cfd86"),
                    ModelName = "Wing 5G",
                    ReleaseDate = new DateTime(2020, 10, 15),
                    RamGb = 8,
                    OS = "Android 10",
                    MakerId = Guid.Parse("e3f51f68-af51-449a-ad85-89ee6ee8be5b")
                },
                new Phone
                {
                    Id = Guid.Parse("4279d25c-9e9d-43c9-bacc-9fe0ff1abc98"),
                    ModelName = "Stylo 6",
                    ReleaseDate = new DateTime(2020, 5, 20),
                    RamGb = 3,
                    OS = "Android 10",
                    MakerId = Guid.Parse("e3f51f68-af51-449a-ad85-89ee6ee8be5b")
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
