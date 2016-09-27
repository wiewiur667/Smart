using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Smart.Data;

namespace Smart.Migrations
{
    [DbContext(typeof(PetsDbContext))]
    partial class PetsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartBowl.Bowl", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AlertAmount");

                    b.Property<decimal>("FoodAmount");

                    b.Property<string>("FoodName");

                    b.Property<string>("Location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("ID");

                    b.ToTable("Bowl");
                });

            modelBuilder.Entity("SmartBowl.BowlPet", b =>
                {
                    b.Property<int>("PetId");

                    b.Property<int>("BowlId");

                    b.HasKey("PetId", "BowlId");

                    b.HasIndex("BowlId");

                    b.HasIndex("PetId");

                    b.ToTable("BowlPet");
                });

            modelBuilder.Entity("SmartBowl.Pet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<decimal>("Weight");

                    b.HasKey("ID");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("SmartBowl.BowlPet", b =>
                {
                    b.HasOne("SmartBowl.Bowl", "Bowl")
                        .WithMany("BowlPet")
                        .HasForeignKey("BowlId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartBowl.Pet", "Pet")
                        .WithMany("BowlPet")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
