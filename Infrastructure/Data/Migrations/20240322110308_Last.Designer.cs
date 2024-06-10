﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(MuseumContext))]
    [Migration("20240322110308_Last")]
    partial class Last
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Core.Entities.ExhibitCulture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ExhibitCulture");
                });

            modelBuilder.Entity("Core.Entities.ExhibitRatingComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExhibitsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TourId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ExhibitsId");

                    b.HasIndex("TourId");

                    b.ToTable("ExhibitRatingComments");
                });

            modelBuilder.Entity("Core.Entities.ExhibitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ExhibitTypes");
                });

            modelBuilder.Entity("Core.Entities.Exhibits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Century")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExhibitCultureId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExhibitTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Period")
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TourTime")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExhibitCultureId");

                    b.HasIndex("ExhibitTypeId");

                    b.ToTable("Exhibits");
                });

            modelBuilder.Entity("Core.Entities.Identity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("FavoriteExhibit")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Core.Entities.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("Core.Entities.TourAggregate.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Subtotal")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TourDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserEmail")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("Core.Entities.TourAggregate.TourItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("TourItems");
                });

            modelBuilder.Entity("Core.Entities.ExhibitRatingComment", b =>
                {
                    b.HasOne("Core.Entities.Identity.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("Core.Entities.Exhibits", "Exhibits")
                        .WithMany("RatingsComments")
                        .HasForeignKey("ExhibitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TourAggregate.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Exhibits");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Core.Entities.Exhibits", b =>
                {
                    b.HasOne("Core.Entities.ExhibitCulture", "ExhibitCulture")
                        .WithMany()
                        .HasForeignKey("ExhibitCultureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ExhibitType", "ExhibitType")
                        .WithMany()
                        .HasForeignKey("ExhibitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExhibitCulture");

                    b.Navigation("ExhibitType");
                });

            modelBuilder.Entity("Core.Entities.Identity.Address", b =>
                {
                    b.HasOne("Core.Entities.Identity.AppUser", "AppUser")
                        .WithOne("Address")
                        .HasForeignKey("Core.Entities.Identity.Address", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Core.Entities.TourAggregate.Tour", b =>
                {
                    b.OwnsOne("Core.Entities.TourAggregate.Address", "UserData", b1 =>
                        {
                            b1.Property<int>("TourId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Birthday")
                                .HasColumnType("TEXT");

                            b1.Property<string>("City")
                                .HasColumnType("TEXT");

                            b1.Property<string>("FavoriteExhibit")
                                .HasColumnType("TEXT");

                            b1.Property<string>("FirstName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("LastName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Phone")
                                .HasColumnType("TEXT");

                            b1.HasKey("TourId");

                            b1.ToTable("Tours");

                            b1.WithOwner()
                                .HasForeignKey("TourId");
                        });

                    b.Navigation("UserData")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.TourAggregate.TourItem", b =>
                {
                    b.HasOne("Core.Entities.TourAggregate.Tour", null)
                        .WithMany("TourItems")
                        .HasForeignKey("TourId");

                    b.OwnsOne("Core.Entities.TourAggregate.ExhibitItemToured", "ExhibitItemToured", b1 =>
                        {
                            b1.Property<int>("TourItemId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("ExhibitItemId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("ExhibitName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("PictureUrl")
                                .HasColumnType("TEXT");

                            b1.HasKey("TourItemId");

                            b1.ToTable("TourItems");

                            b1.WithOwner()
                                .HasForeignKey("TourItemId");
                        });

                    b.Navigation("ExhibitItemToured");
                });

            modelBuilder.Entity("Core.Entities.Exhibits", b =>
                {
                    b.Navigation("RatingsComments");
                });

            modelBuilder.Entity("Core.Entities.Identity.AppUser", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("Core.Entities.TourAggregate.Tour", b =>
                {
                    b.Navigation("TourItems");
                });
#pragma warning restore 612, 618
        }
    }
}
