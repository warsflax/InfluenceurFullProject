﻿// <auto-generated />
using System;
using Influenceur.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Influenceur.Migrations
{
    [DbContext(typeof(MyAppContext))]
    partial class MyAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Influenceur.Models.Identity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IdRectoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdVersoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelfiUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Identities");
                });

            modelBuilder.Entity("Influenceur.Models.SocialMediaAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AgeRange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("FemaleRate")
                        .HasColumnType("float");

                    b.Property<int?>("FollowersCount")
                        .HasColumnType("int");

                    b.Property<string>("Langue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("ManRate")
                        .HasColumnType("float");

                    b.Property<string>("Niches")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlatformName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopCities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopCountries")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SocialMediaAccounts");
                });

            modelBuilder.Entity("Influenceur.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("Influenceur.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code_postale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement_adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_naissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Influenceur.Models.Identity", b =>
                {
                    b.HasOne("Influenceur.Models.User", "User")
                        .WithOne("Identity")
                        .HasForeignKey("Influenceur.Models.Identity", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Influenceur.Models.SocialMediaAccount", b =>
                {
                    b.HasOne("Influenceur.Models.User", "User")
                        .WithMany("SocialMediaAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Influenceur.Models.Sponsor", b =>
                {
                    b.HasOne("Influenceur.Models.User", "User")
                        .WithOne("Sponsor")
                        .HasForeignKey("Influenceur.Models.Sponsor", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Influenceur.Models.User", b =>
                {
                    b.Navigation("Identity");

                    b.Navigation("SocialMediaAccounts");

                    b.Navigation("Sponsor");
                });
#pragma warning restore 612, 618
        }
    }
}
