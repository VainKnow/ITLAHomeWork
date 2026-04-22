
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SenderismoClub.Persistence.Data;

#nullable disable

namespace SenderismoClub.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("SenderismoClub.Domain.Entities.Excursion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("RouteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Excursions");
                });

            modelBuilder.Entity("SenderismoClub.Domain.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("SenderismoClub.Domain.Entities.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Attended")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExcursionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Observations")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExcursionId");

                    b.HasIndex("MemberId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("SenderismoClub.Domain.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<double>("DistanceKm")
                        .HasColumnType("REAL");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("SenderismoClub.Domain.Entities.Excursion", b =>
                {
                    b.HasOne("SenderismoClub.Domain.Entities.Route", "Route")
                        .WithMany("Excursions")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("SenderismoClub.Domain.Entities.Registration", b =>
                {
                    b.HasOne("SenderismoClub.Domain.Entities.Excursion", "Excursion")
                        .WithMany("Registrations")
                        .HasForeignKey("ExcursionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SenderismoClub.Domain.Entities.Member", "Member")
                        .WithMany("Registrations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excursion");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("SenderismoClub.Domain.Entities.Excursion", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("SenderismoClub.Domain.Entities.Member", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("SenderismoClub.Domain.Entities.Route", b =>
                {
                    b.Navigation("Excursions");
                });
#pragma warning restore 612, 618
        }
    }
}
