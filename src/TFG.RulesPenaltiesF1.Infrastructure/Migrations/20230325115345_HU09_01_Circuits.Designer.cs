﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    [DbContext(typeof(RulesPenaltiesF1DbContext))]
    [Migration("20230325115345_HU09_01_Circuits")]
    partial class HU09_01_Circuits
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Circuit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("DriverLapRecord")
                        .HasColumnType("int");

                    b.Property<float>("Laps")
                        .HasColumnType("real");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<int>("MillisecondsLapRecord")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("YearFirstGP")
                        .HasColumnType("int");

                    b.Property<int>("YearLapRecord")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Circuit");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Penalty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PenaltyTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PenaltyTypeId");

                    b.ToTable("Penalty");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Penalty");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.PenaltyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PenaltyType");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate.Regulation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Regulation");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate.RegulationArticle", b =>
                {
                    b.Property<int>("RegulationId")
                        .HasColumnType("int");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.HasKey("RegulationId", "ArticleId");

                    b.HasIndex("ArticleId", "RegulationId")
                        .IsUnique();

                    b.ToTable("RegulationArticle");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate.RegulationPenalty", b =>
                {
                    b.Property<int>("RegulationId")
                        .HasColumnType("int");

                    b.Property<int>("PenaltyId")
                        .HasColumnType("int");

                    b.HasKey("RegulationId", "PenaltyId");

                    b.HasIndex("PenaltyId", "RegulationId")
                        .IsUnique();

                    b.ToTable("RegulationPenalty");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Disqualification", b =>
                {
                    b.HasBaseType("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Penalty");

                    b.Property<bool>("NextCompetition")
                        .HasColumnType("bit");

                    b.HasIndex("NextCompetition", "PenaltyTypeId")
                        .IsUnique()
                        .HasFilter("[NextCompetition] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Disqualification");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Penalties.DriveThrough", b =>
                {
                    b.HasBaseType("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Penalty");

                    b.Property<int>("ElapsedSeconds")
                        .HasColumnType("int");

                    b.HasIndex("ElapsedSeconds", "PenaltyTypeId")
                        .IsUnique()
                        .HasFilter("[ElapsedSeconds] IS NOT NULL");

                    b.HasDiscriminator().HasValue("DriveThrough");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Penalties.DropGridPositions", b =>
                {
                    b.HasBaseType("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Penalty");

                    b.Property<int>("Positions")
                        .HasColumnType("int");

                    b.HasIndex("Positions", "PenaltyTypeId")
                        .IsUnique()
                        .HasFilter("[Positions] IS NOT NULL");

                    b.HasDiscriminator().HasValue("DropGridPositions");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Fine", b =>
                {
                    b.HasBaseType("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Penalty");

                    b.HasDiscriminator().HasValue("Fine");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Reprimand", b =>
                {
                    b.HasBaseType("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Penalty");

                    b.Property<bool>("DrivingReprimand")
                        .HasColumnType("bit");

                    b.HasIndex("DrivingReprimand", "PenaltyTypeId")
                        .IsUnique()
                        .HasFilter("[DrivingReprimand] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Reprimand");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Penalties.TimePenalty", b =>
                {
                    b.HasBaseType("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Penalty");

                    b.Property<int>("Seconds")
                        .HasColumnType("int");

                    b.HasIndex("Seconds", "PenaltyTypeId")
                        .IsUnique()
                        .HasFilter("[Seconds] IS NOT NULL");

                    b.ToTable("Penalty", t =>
                        {
                            t.Property("Seconds")
                                .HasColumnName("TimePenalty_Seconds");
                        });

                    b.HasDiscriminator().HasValue("TimePenalty");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Penalties.StopAndGo", b =>
                {
                    b.HasBaseType("TFG.RulesPenaltiesF1.Core.Entities.Penalties.DriveThrough");

                    b.Property<int>("Seconds")
                        .HasColumnType("int");

                    b.HasIndex("ElapsedSeconds", "Seconds", "PenaltyTypeId")
                        .IsUnique()
                        .HasFilter("[ElapsedSeconds] IS NOT NULL AND [Seconds] IS NOT NULL");

                    b.HasDiscriminator().HasValue("StopAndGo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Article", b =>
                {
                    b.HasOne("TFG.RulesPenaltiesF1.Core.Entities.Article", null)
                        .WithMany("SubArticles")
                        .HasForeignKey("ArticleId");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Circuit", b =>
                {
                    b.HasOne("TFG.RulesPenaltiesF1.Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Penalty", b =>
                {
                    b.HasOne("TFG.RulesPenaltiesF1.Core.Entities.PenaltyType", "PenaltyType")
                        .WithMany()
                        .HasForeignKey("PenaltyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PenaltyType");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate.RegulationArticle", b =>
                {
                    b.HasOne("TFG.RulesPenaltiesF1.Core.Entities.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate.Regulation", "Regulation")
                        .WithMany("Articles")
                        .HasForeignKey("RegulationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Regulation");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate.RegulationPenalty", b =>
                {
                    b.HasOne("TFG.RulesPenaltiesF1.Core.Entities.Penalties.Penalty", "Penalty")
                        .WithMany()
                        .HasForeignKey("PenaltyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate.Regulation", "Regulation")
                        .WithMany("Penalties")
                        .HasForeignKey("RegulationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Penalty");

                    b.Navigation("Regulation");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Article", b =>
                {
                    b.Navigation("SubArticles");
                });

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate.Regulation", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Penalties");
                });
#pragma warning restore 612, 618
        }
    }
}
