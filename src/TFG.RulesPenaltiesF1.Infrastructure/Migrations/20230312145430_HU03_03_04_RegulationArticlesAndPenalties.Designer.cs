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
    [Migration("20230312145430_HU03_03_04_RegulationArticlesAndPenalties")]
    partial class HU03_03_04_RegulationArticlesAndPenalties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("TFG.RulesPenaltiesF1.Core.Entities.Article", b =>
                {
                    b.HasOne("TFG.RulesPenaltiesF1.Core.Entities.Article", null)
                        .WithMany("SubArticles")
                        .HasForeignKey("ArticleId");
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
