﻿using data.models.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.context
{
    public class Context : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                Settings = new AppConfiguration();
                OptionsBuilder = new DbContextOptionsBuilder<Context>();
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                Options = OptionsBuilder.Options;
            }
            public DbContextOptionsBuilder<Context> OptionsBuilder { get; set; }
            public DbContextOptions<Context> Options { get; set; }

            private AppConfiguration Settings { get; set; }

        }

        public static OptionsBuild Option = new OptionsBuild();

        public Context(DbContextOptions<Context> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        public DbSet<Education> Educations { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Project_User> Project_User { get; set; }

        public DbSet<Project> Project { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Unique indexes

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Education>()
                .HasIndex(e => e.Name)
                .IsUnique();



            //Relation between models

            modelBuilder.Entity<User>()
                .HasMany(u => u.Invitations)
                .WithOne();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Education)
                .WithMany(e => e.Users)
                .HasForeignKey(u => u.Education_Id);


            modelBuilder.Entity<User>()
                .HasMany(u => u.Joined_Projects)
                .WithOne();

            modelBuilder.Entity<Project>()
                .HasOne(p=> p.User)
                .WithMany(u => u.Created_Projects)
                .HasForeignKey(p => p.User_Id);

            modelBuilder.Entity<Project>()
                .HasOne(p=> p.Category)
                .WithMany(c=> c.Projects)
                .HasForeignKey(p => p.Category_Id);


            modelBuilder.Entity<Project>()
                .HasMany(p => p.Project_Users)
                .WithOne();
            
        }
    }
}