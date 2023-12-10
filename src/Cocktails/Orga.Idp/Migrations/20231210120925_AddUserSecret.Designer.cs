﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orga.Idp.DbContexts;

#nullable disable

namespace Orga.Idp.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20231210120925_AddUserSecret")]
    partial class AddUserSecret
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("Orga.Idp.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityCode")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SecurityCodeExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Subject")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                            Active = true,
                            ConcurrencyStamp = "c45762ac-c9d8-4942-aecb-b020412f077a",
                            Email = "johnny@emailprovider.com",
                            Password = "password",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "ac46ef56-2155-4d0b-afd0-d10c5e7c89b1",
                            UserName = "Johnny"
                        },
                        new
                        {
                            Id = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Active = true,
                            ConcurrencyStamp = "6456542b-527e-4939-97a4-4921bc4171ea",
                            Email = "linda@emailprovider.com",
                            Password = "password",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "bcc4c51b-d20b-41dc-8152-cc7ed69c62c7",
                            UserName = "Linda"
                        });
                });

            modelBuilder.Entity("Orga.Idp.Entities.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");

                    b.HasData(
                        new
                        {
                            Id = new Guid("efb0efce-6eb9-4a57-bfff-fa2f150ca952"),
                            ConcurrencyStamp = "01a4564b-9729-4d10-b9cb-835e8bc193d3",
                            Type = "given_name",
                            UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                            Value = "Johnny"
                        },
                        new
                        {
                            Id = new Guid("77ad9808-d3f3-42ae-a70c-57288109e94e"),
                            ConcurrencyStamp = "e845f2b3-d433-42e8-8a38-5dac9c6055c8",
                            Type = "family_name",
                            UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                            Value = "Oldman"
                        },
                        new
                        {
                            Id = new Guid("229c4bb7-0cbf-44ab-aaf8-2684fb1f1fa1"),
                            ConcurrencyStamp = "70787a21-39f6-442b-b235-389ae0490da2",
                            Type = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth",
                            UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                            Value = "11/06/2003"
                        },
                        new
                        {
                            Id = new Guid("d10c2a4a-e4d4-49da-8cd6-2f167be94ca6"),
                            ConcurrencyStamp = "fcf44fa5-11b1-45c3-897a-94573397c7a5",
                            Type = "role",
                            UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                            Value = "admin"
                        },
                        new
                        {
                            Id = new Guid("16ac1be5-ecb4-4622-88fd-60d112a0a2b4"),
                            ConcurrencyStamp = "8559dd5a-be33-4981-a5e1-9c191f1d0885",
                            Type = "country",
                            UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                            Value = "pt"
                        },
                        new
                        {
                            Id = new Guid("6692e4e8-af0d-40a7-8a6e-8c74bf0beb5f"),
                            ConcurrencyStamp = "0d44645a-746d-443b-b935-159def43275c",
                            Type = "given_name",
                            UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Value = "Linda"
                        },
                        new
                        {
                            Id = new Guid("4731b610-8d53-4897-ad72-52d579124686"),
                            ConcurrencyStamp = "582b95a8-e755-4576-b7e4-6f43aa4bf26b",
                            Type = "family_name",
                            UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Value = "Young"
                        },
                        new
                        {
                            Id = new Guid("efeedd6a-047d-4cca-aa76-4830d0635bf0"),
                            ConcurrencyStamp = "24c3f630-0047-4907-b13d-e007c11b30d5",
                            Type = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth",
                            UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Value = "11/06/2013"
                        },
                        new
                        {
                            Id = new Guid("13640081-654d-4ddb-8f95-5df64c2de579"),
                            ConcurrencyStamp = "1b8b4606-3eb6-492b-94a9-ee8d1c1472e7",
                            Type = "role",
                            UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Value = "user"
                        },
                        new
                        {
                            Id = new Guid("4ba21ec6-d596-4436-b3b6-73f952728350"),
                            ConcurrencyStamp = "6c248649-9ec7-4b79-abd2-a671b47bb9f2",
                            Type = "country",
                            UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Value = "nl"
                        });
                });

            modelBuilder.Entity("Orga.Idp.Entities.UserLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderIdentityKey")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Orga.Idp.Entities.UserSecret", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSecrets");
                });

            modelBuilder.Entity("Orga.Idp.Entities.UserClaim", b =>
                {
                    b.HasOne("Orga.Idp.Entities.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Orga.Idp.Entities.UserLogin", b =>
                {
                    b.HasOne("Orga.Idp.Entities.User", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Orga.Idp.Entities.UserSecret", b =>
                {
                    b.HasOne("Orga.Idp.Entities.User", "User")
                        .WithMany("Secrets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Orga.Idp.Entities.User", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Logins");

                    b.Navigation("Secrets");
                });
#pragma warning restore 612, 618
        }
    }
}
