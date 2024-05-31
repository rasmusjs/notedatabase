﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lars_notedatabase.DAL;

#nullable disable

namespace lars_notedatabase.Migrations
{
    [DbContext(typeof(NoteDbContext))]
    [Migration("20231212174224_main")]
    partial class main
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("Contributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("Birth_date");

                    b.Property<int?>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("Death_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasColumnName("Description");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("First_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Last_name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("ContributorRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContributorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrchestralSetId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContributorId");

                    b.HasIndex("OrchestralSetId");

                    b.ToTable("ContributorRole");
                });

            modelBuilder.Entity("InstrumentOrchestralSet", b =>
                {
                    b.Property<int>("OrchestralSetInstrumentsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrchestralSetsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrchestralSetInstrumentsId", "OrchestralSetsId");

                    b.HasIndex("OrchestralSetsId");

                    b.ToTable("InstrumentOrchestralSet");
                });

            modelBuilder.Entity("Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrchestralSetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrchestralSetId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("OrchestralSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("date")
                        .HasColumnName("Created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("date")
                        .HasColumnName("Updated_date");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Orchestral_sets");
                });

            modelBuilder.Entity("lars_notedatabase.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("lars_notedatabase.Models.FileAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActualName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("Actual_name");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("File_path");

                    b.Property<int>("OrchestralSetId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Orchestral_set_id");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("Upload_date");

                    b.HasKey("Id");

                    b.HasIndex("OrchestralSetId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("lars_notedatabase.Models.Instrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("Contributor", b =>
                {
                    b.HasOne("lars_notedatabase.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ContributorRole", b =>
                {
                    b.HasOne("Contributor", "Contributor")
                        .WithMany()
                        .HasForeignKey("ContributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrchestralSet", null)
                        .WithMany("OrchestralSetContributors")
                        .HasForeignKey("OrchestralSetId");

                    b.Navigation("Contributor");
                });

            modelBuilder.Entity("InstrumentOrchestralSet", b =>
                {
                    b.HasOne("lars_notedatabase.Models.Instrument", null)
                        .WithMany()
                        .HasForeignKey("OrchestralSetInstrumentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrchestralSet", null)
                        .WithMany()
                        .HasForeignKey("OrchestralSetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Link", b =>
                {
                    b.HasOne("OrchestralSet", null)
                        .WithMany("Links")
                        .HasForeignKey("OrchestralSetId");
                });

            modelBuilder.Entity("OrchestralSet", b =>
                {
                    b.HasOne("lars_notedatabase.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("lars_notedatabase.Models.FileAttachment", b =>
                {
                    b.HasOne("OrchestralSet", "OrchestralSet")
                        .WithMany("Files")
                        .HasForeignKey("OrchestralSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrchestralSet");
                });

            modelBuilder.Entity("OrchestralSet", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Links");

                    b.Navigation("OrchestralSetContributors");
                });
#pragma warning restore 612, 618
        }
    }
}
