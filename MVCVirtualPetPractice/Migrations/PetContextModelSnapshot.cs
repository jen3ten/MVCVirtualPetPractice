﻿// <auto-generated />
using MVCVirtualPetPractice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCVirtualPetPractice.Migrations
{
    [DbContext(typeof(PetContext))]
    partial class PetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCVirtualPetPractice.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Pets");

                    b.HasData(
                        new { Id = 1, Description = "What a lazy dog!", Name = "Roscoe" },
                        new { Id = 2, Description = "He gets his name because he loves to eat.", Name = "Biggs" },
                        new { Id = 3, Description = "Bella looks tough, but she's a scaredy cat.", Name = "Bella" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
