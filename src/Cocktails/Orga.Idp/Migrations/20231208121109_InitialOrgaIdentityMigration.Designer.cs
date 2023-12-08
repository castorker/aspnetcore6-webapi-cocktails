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
    [Migration("20231208121109_InitialOrgaIdentityMigration")]
    partial class InitialOrgaIdentityMigration
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

                    b.Property<string>("Password")
                        .HasMaxLength(200)
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
                            ConcurrencyStamp = "1fc56e00-19ad-4bc8-897f-edb7d8cb11e9",
                            Password = "password",
                            Subject = "ac46ef56-2155-4d0b-afd0-d10c5e7c89b1",
                            UserName = "Johnny"
                        },
                        new
                        {
                            Id = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Active = true,
                            ConcurrencyStamp = "41225e1b-7e2c-422c-9802-5b7235dd8e00",
                            Password = "password",
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
                            Id = new Guid("e3f15ca2-6911-43ae-a33a-51252d4c32b1"),
                            ConcurrencyStamp = "da4a1e94-b9a3-43f3-9917-7a138426449d",
                            Type = "given_name",
                            UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                            Value = "Johnny"
                        },
                        new
                        {
                            Id = new Guid("5ae9db07-cc14-4aa1-8fa7-cb2e005f9cda"),
                            ConcurrencyStamp = "df460755-d997-4b0b-9cf2-795cf8c5d6a3",
                            Type = "family_name",
                            UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                            Value = "Oldman"
                        },
                        new
                        {
                            Id = new Guid("6542efbb-69f2-44c1-aded-765465c5b299"),
                            ConcurrencyStamp = "171fed9f-03a5-4518-9942-09cc124a659e",
                            Type = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth",
                            UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                            Value = "11/06/2003"
                        },
                        new
                        {
                            Id = new Guid("b2e5b090-fe25-4a70-a859-9c05307489d2"),
                            ConcurrencyStamp = "36e6626d-361f-4932-ba1a-fd1d8a0841cc",
                            Type = "role",
                            UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                            Value = "admin"
                        },
                        new
                        {
                            Id = new Guid("bc907271-ac82-4741-897f-96797a85babb"),
                            ConcurrencyStamp = "85c83c6e-6255-4d14-988b-e7f80aec1d64",
                            Type = "country",
                            UserId = new Guid("57d1c22c-032b-4846-b681-a19db26a5ec6"),
                            Value = "pt"
                        },
                        new
                        {
                            Id = new Guid("bc6ff57c-c7ad-425f-84b6-910bbb79a3db"),
                            ConcurrencyStamp = "2bc1110b-f20b-41c6-81fc-d264c6225b80",
                            Type = "given_name",
                            UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Value = "Linda"
                        },
                        new
                        {
                            Id = new Guid("cf7c091d-dd51-4399-a33d-87aed849811c"),
                            ConcurrencyStamp = "5e081466-3c87-4a29-bafe-1e349fc600c3",
                            Type = "family_name",
                            UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Value = "Young"
                        },
                        new
                        {
                            Id = new Guid("a5e38906-fafd-447d-9698-901bb24e553c"),
                            ConcurrencyStamp = "afec1637-cc38-459f-b3a0-aed4c18ca1a4",
                            Type = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth",
                            UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Value = "11/06/2013"
                        },
                        new
                        {
                            Id = new Guid("71e60714-ba0e-4141-92e7-122c072e642a"),
                            ConcurrencyStamp = "e0188b37-4f8e-425c-a073-4c1f1845d28f",
                            Type = "role",
                            UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Value = "user"
                        },
                        new
                        {
                            Id = new Guid("62f94c21-cd54-40f3-90d2-fd6f2f3eb8a6"),
                            ConcurrencyStamp = "91812d33-fae6-477d-aad7-2e2ec6d16bfa",
                            Type = "country",
                            UserId = new Guid("56c70a51-30a3-4b4f-99b5-87585454c5e8"),
                            Value = "nl"
                        });
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

            modelBuilder.Entity("Orga.Idp.Entities.User", b =>
                {
                    b.Navigation("Claims");
                });
#pragma warning restore 612, 618
        }
    }
}