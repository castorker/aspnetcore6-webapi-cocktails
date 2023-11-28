﻿// <auto-generated />
using Cocktails.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cocktails.API.Migrations
{
    [DbContext(typeof(CocktailsDbContext))]
    partial class CocktailsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("CocktailIngredient", b =>
                {
                    b.Property<int>("CocktailsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IngredientsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CocktailsId", "IngredientsId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("CocktailIngredient");

                    b.HasData(
                        new
                        {
                            CocktailsId = 1,
                            IngredientsId = 1
                        },
                        new
                        {
                            CocktailsId = 1,
                            IngredientsId = 2
                        },
                        new
                        {
                            CocktailsId = 1,
                            IngredientsId = 3
                        },
                        new
                        {
                            CocktailsId = 2,
                            IngredientsId = 4
                        },
                        new
                        {
                            CocktailsId = 2,
                            IngredientsId = 5
                        },
                        new
                        {
                            CocktailsId = 2,
                            IngredientsId = 6
                        },
                        new
                        {
                            CocktailsId = 3,
                            IngredientsId = 7
                        },
                        new
                        {
                            CocktailsId = 3,
                            IngredientsId = 8
                        },
                        new
                        {
                            CocktailsId = 3,
                            IngredientsId = 9
                        },
                        new
                        {
                            CocktailsId = 3,
                            IngredientsId = 10
                        },
                        new
                        {
                            CocktailsId = 3,
                            IngredientsId = 11
                        },
                        new
                        {
                            CocktailsId = 3,
                            IngredientsId = 12
                        },
                        new
                        {
                            CocktailsId = 3,
                            IngredientsId = 13
                        },
                        new
                        {
                            CocktailsId = 4,
                            IngredientsId = 7
                        },
                        new
                        {
                            CocktailsId = 4,
                            IngredientsId = 14
                        },
                        new
                        {
                            CocktailsId = 4,
                            IngredientsId = 15
                        },
                        new
                        {
                            CocktailsId = 5,
                            IngredientsId = 16
                        },
                        new
                        {
                            CocktailsId = 5,
                            IngredientsId = 17
                        },
                        new
                        {
                            CocktailsId = 5,
                            IngredientsId = 18
                        },
                        new
                        {
                            CocktailsId = 5,
                            IngredientsId = 19
                        },
                        new
                        {
                            CocktailsId = 6,
                            IngredientsId = 7
                        },
                        new
                        {
                            CocktailsId = 6,
                            IngredientsId = 20
                        },
                        new
                        {
                            CocktailsId = 6,
                            IngredientsId = 21
                        },
                        new
                        {
                            CocktailsId = 6,
                            IngredientsId = 22
                        },
                        new
                        {
                            CocktailsId = 7,
                            IngredientsId = 7
                        },
                        new
                        {
                            CocktailsId = 7,
                            IngredientsId = 20
                        },
                        new
                        {
                            CocktailsId = 7,
                            IngredientsId = 23
                        },
                        new
                        {
                            CocktailsId = 8,
                            IngredientsId = 7
                        },
                        new
                        {
                            CocktailsId = 8,
                            IngredientsId = 21
                        },
                        new
                        {
                            CocktailsId = 8,
                            IngredientsId = 24
                        },
                        new
                        {
                            CocktailsId = 8,
                            IngredientsId = 4
                        },
                        new
                        {
                            CocktailsId = 9,
                            IngredientsId = 25
                        },
                        new
                        {
                            CocktailsId = 9,
                            IngredientsId = 26
                        },
                        new
                        {
                            CocktailsId = 10,
                            IngredientsId = 9
                        },
                        new
                        {
                            CocktailsId = 10,
                            IngredientsId = 17
                        },
                        new
                        {
                            CocktailsId = 10,
                            IngredientsId = 27
                        },
                        new
                        {
                            CocktailsId = 11,
                            IngredientsId = 28
                        },
                        new
                        {
                            CocktailsId = 11,
                            IngredientsId = 2
                        },
                        new
                        {
                            CocktailsId = 11,
                            IngredientsId = 29
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 25
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 30
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 31
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 32
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 33
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 34
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 35
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 36
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 37
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 38
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 39
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 40
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 19
                        },
                        new
                        {
                            CocktailsId = 12,
                            IngredientsId = 41
                        },
                        new
                        {
                            CocktailsId = 13,
                            IngredientsId = 42
                        },
                        new
                        {
                            CocktailsId = 13,
                            IngredientsId = 41
                        },
                        new
                        {
                            CocktailsId = 13,
                            IngredientsId = 43
                        },
                        new
                        {
                            CocktailsId = 14,
                            IngredientsId = 42
                        },
                        new
                        {
                            CocktailsId = 14,
                            IngredientsId = 41
                        },
                        new
                        {
                            CocktailsId = 14,
                            IngredientsId = 44
                        },
                        new
                        {
                            CocktailsId = 15,
                            IngredientsId = 42
                        },
                        new
                        {
                            CocktailsId = 15,
                            IngredientsId = 18
                        },
                        new
                        {
                            CocktailsId = 15,
                            IngredientsId = 41
                        },
                        new
                        {
                            CocktailsId = 16,
                            IngredientsId = 45
                        },
                        new
                        {
                            CocktailsId = 16,
                            IngredientsId = 46
                        },
                        new
                        {
                            CocktailsId = 16,
                            IngredientsId = 47
                        },
                        new
                        {
                            CocktailsId = 16,
                            IngredientsId = 41
                        },
                        new
                        {
                            CocktailsId = 17,
                            IngredientsId = 25
                        },
                        new
                        {
                            CocktailsId = 17,
                            IngredientsId = 21
                        },
                        new
                        {
                            CocktailsId = 18,
                            IngredientsId = 25
                        },
                        new
                        {
                            CocktailsId = 18,
                            IngredientsId = 48
                        },
                        new
                        {
                            CocktailsId = 18,
                            IngredientsId = 49
                        },
                        new
                        {
                            CocktailsId = 19,
                            IngredientsId = 25
                        },
                        new
                        {
                            CocktailsId = 19,
                            IngredientsId = 50
                        },
                        new
                        {
                            CocktailsId = 19,
                            IngredientsId = 41
                        },
                        new
                        {
                            CocktailsId = 19,
                            IngredientsId = 51
                        },
                        new
                        {
                            CocktailsId = 19,
                            IngredientsId = 52
                        },
                        new
                        {
                            CocktailsId = 20,
                            IngredientsId = 53
                        },
                        new
                        {
                            CocktailsId = 20,
                            IngredientsId = 54
                        },
                        new
                        {
                            CocktailsId = 20,
                            IngredientsId = 55
                        },
                        new
                        {
                            CocktailsId = 21,
                            IngredientsId = 53
                        },
                        new
                        {
                            CocktailsId = 21,
                            IngredientsId = 56
                        },
                        new
                        {
                            CocktailsId = 21,
                            IngredientsId = 29
                        },
                        new
                        {
                            CocktailsId = 22,
                            IngredientsId = 53
                        },
                        new
                        {
                            CocktailsId = 22,
                            IngredientsId = 57
                        },
                        new
                        {
                            CocktailsId = 23,
                            IngredientsId = 58
                        },
                        new
                        {
                            CocktailsId = 23,
                            IngredientsId = 59
                        });
                });

            modelBuilder.Entity("Cocktails.API.Entities.Cocktail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cocktails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Caipirinha"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Chrysanthemum"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hangman's Blood"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Angel Face"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Between the sheets"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Damn the weather"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Hanky panky"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Monkey Gland"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Salty dog"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Fish house punch"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Tamagozake"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Bloody Mary"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Paloma"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Batanga"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Margarita"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Naked and famous"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Screwdriver"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Sea breeze"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Spicy Fifty"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Old pal"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Amber moon"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Farnell"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Rusty nail"
                        });
                });

            modelBuilder.Entity("Cocktails.API.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cachaça"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sugar"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lime"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Absinthe"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bénédictine"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Vermouth"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Gin"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Whisky"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Rum"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Port"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Brandy"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Stout"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Champagne"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Apricot"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Calvados"
                        },
                        new
                        {
                            Id = 16,
                            Name = "White rum"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Cognac"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Triple sec"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Lemon juice"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Sweet vermouth"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Orange juice"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Sweetener"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Fernet-Branca"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Grenadine"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Vodka"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Grapefruit"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Peach brandy"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Heated sake"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Raw egg"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Tomato juice"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Worcestershire sauce"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Hot sauces"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Garlic"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Herbs"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Horseradish"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Celery"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Olives"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Pickled vegetables"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Salt"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Black pepper"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Lime juice"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Tequila"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Grapefruit-flavored soda"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Cola"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Mezcal"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Yellow Chartreuse"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Aperol"
                        },
                        new
                        {
                            Id = 48,
                            Name = "Cranberry juice"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Grapefruit juice"
                        },
                        new
                        {
                            Id = 50,
                            Name = "Elderflower cordial"
                        },
                        new
                        {
                            Id = 51,
                            Name = "Honey syrup"
                        },
                        new
                        {
                            Id = 52,
                            Name = "Red chili pepper"
                        },
                        new
                        {
                            Id = 53,
                            Name = "Whiskey"
                        },
                        new
                        {
                            Id = 54,
                            Name = "French vermouth (dry)"
                        },
                        new
                        {
                            Id = 55,
                            Name = "Campari"
                        },
                        new
                        {
                            Id = 56,
                            Name = "Tabasco sauce"
                        },
                        new
                        {
                            Id = 57,
                            Name = "Lemonade"
                        },
                        new
                        {
                            Id = 58,
                            Name = "Scotch whisky"
                        },
                        new
                        {
                            Id = 59,
                            Name = "Drambuie"
                        });
                });

            modelBuilder.Entity("CocktailIngredient", b =>
                {
                    b.HasOne("Cocktails.API.Entities.Cocktail", null)
                        .WithMany()
                        .HasForeignKey("CocktailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cocktails.API.Entities.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
