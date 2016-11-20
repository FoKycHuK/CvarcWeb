﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CvarcWeb.Data;

namespace CvarcWeb.Migrations
{
    [DbContext(typeof(CvarcDbContext))]
    [Migration("20161120200529_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CvarcWeb.Models.Command", b =>
                {
                    b.Property<int>("CommandId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CvarcTag");

                    b.Property<string>("LinkToImage");

                    b.Property<string>("Name");

                    b.HasKey("CommandId");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("CvarcWeb.Models.CommandGameResult", b =>
                {
                    b.Property<int>("CommandGameResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommandId");

                    b.Property<int>("GameId");

                    b.HasKey("CommandGameResultId");

                    b.HasIndex("CommandId");

                    b.HasIndex("GameId");

                    b.ToTable("CommandGameResults");
                });

            modelBuilder.Entity("CvarcWeb.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GameName");

                    b.Property<string>("PathToLog");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("CvarcWeb.Models.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommandGameResultId");

                    b.Property<int>("Scores");

                    b.Property<string>("ScoresType");

                    b.HasKey("ResultId");

                    b.HasIndex("CommandGameResultId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("CvarcWeb.Models.CommandGameResult", b =>
                {
                    b.HasOne("CvarcWeb.Models.Command", "Command")
                        .WithMany()
                        .HasForeignKey("CommandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CvarcWeb.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CvarcWeb.Models.Result", b =>
                {
                    b.HasOne("CvarcWeb.Models.CommandGameResult", "CommandGameResult")
                        .WithMany("Results")
                        .HasForeignKey("CommandGameResultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}