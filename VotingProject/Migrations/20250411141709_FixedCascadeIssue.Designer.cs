﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VotingProject.Models;

#nullable disable

namespace VotingProject.Migrations
{
    [DbContext(typeof(VoteContext))]
    [Migration("20250411141709_FixedCascadeIssue")]
    partial class FixedCascadeIssue
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VotingProject.Models.TbVote", b =>
                {
                    b.Property<int>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoteId"));

                    b.Property<string>("VoteDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("VoteName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("VoteId");

                    b.ToTable("TbVote");
                });

            modelBuilder.Entity("VotingProject.Models.TbVoteOption", b =>
                {
                    b.Property<int>("VoteOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoteOptionId"));

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("VoteId")
                        .HasColumnType("int");

                    b.HasKey("VoteOptionId");

                    b.HasIndex("VoteId");

                    b.ToTable("TbVoteOption");
                });

            modelBuilder.Entity("VotingProject.Models.TbVoteResult", b =>
                {
                    b.Property<int>("VoterResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoterResultId"));

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.Property<int>("PersonExperence")
                        .HasColumnType("int");

                    b.Property<string>("PersonJob")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PersonNote")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("VoteId")
                        .HasColumnType("int");

                    b.HasKey("VoterResultId");

                    b.HasIndex("OptionId");

                    b.HasIndex("VoteId");

                    b.ToTable("TbVoteResult");
                });

            modelBuilder.Entity("VotingProject.Models.TbVoteOption", b =>
                {
                    b.HasOne("VotingProject.Models.TbVote", "Vote")
                        .WithMany("Options")
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vote");
                });

            modelBuilder.Entity("VotingProject.Models.TbVoteResult", b =>
                {
                    b.HasOne("VotingProject.Models.TbVoteOption", "Option")
                        .WithMany("Results")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VotingProject.Models.TbVote", "Vote")
                        .WithMany("VoteResults")
                        .HasForeignKey("VoteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("Vote");
                });

            modelBuilder.Entity("VotingProject.Models.TbVote", b =>
                {
                    b.Navigation("Options");

                    b.Navigation("VoteResults");
                });

            modelBuilder.Entity("VotingProject.Models.TbVoteOption", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
