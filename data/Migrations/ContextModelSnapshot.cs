﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data.context;

#nullable disable

namespace data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("data.models.entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("data.models.entities.Education", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Department_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("data.models.entities.Invitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Project_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Project_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("data.models.entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Category_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<int>("Max_Users")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Category_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("data.models.entities.Project_User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Project_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Project_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Project_User");
                });

            modelBuilder.Entity("data.models.entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("Education_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("User_Created_Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Education_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("data.models.entities.UserCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Category_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Category_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("UserCategories");
                });

            modelBuilder.Entity("data.models.entities.Invitation", b =>
                {
                    b.HasOne("data.models.entities.User", null)
                        .WithMany("Invitations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("data.models.entities.Project", b =>
                {
                    b.HasOne("data.models.entities.Category", "Category")
                        .WithMany("Projects")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data.models.entities.User", "User")
                        .WithMany("Created_Projects")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("data.models.entities.Project_User", b =>
                {
                    b.HasOne("data.models.entities.Project", "Project")
                        .WithMany("Project_Users")
                        .HasForeignKey("Project_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("data.models.entities.User", "User")
                        .WithMany("Joined_Projects")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("data.models.entities.User", b =>
                {
                    b.HasOne("data.models.entities.Education", "Education")
                        .WithMany("Users")
                        .HasForeignKey("Education_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Education");
                });

            modelBuilder.Entity("data.models.entities.UserCategory", b =>
                {
                    b.HasOne("data.models.entities.Category", "Category")
                        .WithMany("UserCategory")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("data.models.entities.User", "User")
                        .WithMany("Interests")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("data.models.entities.Category", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("UserCategory");
                });

            modelBuilder.Entity("data.models.entities.Education", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("data.models.entities.Project", b =>
                {
                    b.Navigation("Project_Users");
                });

            modelBuilder.Entity("data.models.entities.User", b =>
                {
                    b.Navigation("Created_Projects");

                    b.Navigation("Interests");

                    b.Navigation("Invitations");

                    b.Navigation("Joined_Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
