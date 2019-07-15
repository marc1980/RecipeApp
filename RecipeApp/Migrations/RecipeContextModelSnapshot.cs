﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeApp.Data;

namespace RecipeApp.Migrations
{
    [DbContext(typeof(RecipeContext))]
    partial class RecipeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("RecipeApp.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("Name");

                    b.Property<int>("RecipeId");

                    b.Property<int>("Unit");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("RecipeApp.Models.PreparationStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Rank");

                    b.Property<int>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("PreparationSteps");
                });

            modelBuilder.Entity("RecipeApp.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeApp.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int>("RecipeId");

                    b.Property<string>("Reviewer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("RecipeApp.Models.Ingredient", b =>
                {
                    b.HasOne("RecipeApp.Models.Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecipeApp.Models.PreparationStep", b =>
                {
                    b.HasOne("RecipeApp.Models.Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecipeApp.Models.Review", b =>
                {
                    b.HasOne("RecipeApp.Models.Recipe")
                        .WithMany("Reviews")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
