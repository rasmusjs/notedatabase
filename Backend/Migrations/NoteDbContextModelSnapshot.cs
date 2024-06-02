﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lars_notedatabase.DAL;

#nullable disable

namespace lars_notedatabase.Migrations
{
    [DbContext(typeof(NoteDbContext))]
    partial class NoteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("InstrumentOrchestralSet", b =>
                {
                    b.Property<int>("InstrumentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InstrumentsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("InstrumentId", "InstrumentsId");

                    b.ToTable("InstrumentOrchestralSet");
                });

            modelBuilder.Entity("OrchestralSetInstrument", b =>
                {
                    b.Property<int>("OrchestralSetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InstrumentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrchestralSetId", "InstrumentId");

                    b.HasIndex("InstrumentId");

                    b.ToTable("OrchestralSetInstrument");
                });

            modelBuilder.Entity("lars_notedatabase.Models.Contributor", b =>
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

            modelBuilder.Entity("lars_notedatabase.Models.ContributorRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContributorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrchestralSetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContributorId");

                    b.HasIndex("OrchestralSetId");

                    b.ToTable("ContributorRoles");
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

            modelBuilder.Entity("lars_notedatabase.Models.Link", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrchestralSetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrchestralSetId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("lars_notedatabase.Models.OrchestralSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryId");

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

            modelBuilder.Entity("OrchestralSetInstrument", b =>
                {
                    b.HasOne("lars_notedatabase.Models.Instrument", null)
                        .WithMany()
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_OrchestralSetInstrument_InstrumentId");

                    b.HasOne("lars_notedatabase.Models.OrchestralSet", null)
                        .WithMany()
                        .HasForeignKey("OrchestralSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_OrchestralSetInstrument_OrchestralSetId");
                });

            modelBuilder.Entity("lars_notedatabase.Models.Contributor", b =>
                {
                    b.HasOne("lars_notedatabase.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("lars_notedatabase.Models.ContributorRole", b =>
                {
                    b.HasOne("lars_notedatabase.Models.Contributor", "Contributor")
                        .WithMany("ContributorRoles")
                        .HasForeignKey("ContributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lars_notedatabase.Models.OrchestralSet", null)
                        .WithMany("Contributors")
                        .HasForeignKey("OrchestralSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contributor");
                });

            modelBuilder.Entity("lars_notedatabase.Models.FileAttachment", b =>
                {
                    b.HasOne("lars_notedatabase.Models.OrchestralSet", "OrchestralSet")
                        .WithMany("Files")
                        .HasForeignKey("OrchestralSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrchestralSet");
                });

            modelBuilder.Entity("lars_notedatabase.Models.Link", b =>
                {
                    b.HasOne("lars_notedatabase.Models.OrchestralSet", null)
                        .WithMany("Links")
                        .HasForeignKey("OrchestralSetId");
                });

            modelBuilder.Entity("lars_notedatabase.Models.OrchestralSet", b =>
                {
                    b.HasOne("lars_notedatabase.Models.Country", "Country")
                        .WithMany("OrchestralSets")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("lars_notedatabase.Models.Contributor", b =>
                {
                    b.Navigation("ContributorRoles");
                });

            modelBuilder.Entity("lars_notedatabase.Models.Country", b =>
                {
                    b.Navigation("OrchestralSets");
                });

            modelBuilder.Entity("lars_notedatabase.Models.OrchestralSet", b =>
                {
                    b.Navigation("Contributors");

                    b.Navigation("Files");

                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
