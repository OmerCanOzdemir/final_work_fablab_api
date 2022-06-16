using data.models.entities;
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

       

        public DbSet<Project> Project { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<ProjectUser> Project_User { get; set; }
     
        public DbSet<TaskModel> Tasks { get; set; }


        public DbSet<Comment> Comments { get; set; }



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
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);
                

            modelBuilder.Entity<User>()
                .HasOne(u => u.Education)
                .WithMany(e => e.Users)
                .HasForeignKey(u => u.Education_Id);


            modelBuilder.Entity<User>()
                .HasMany(u => u.Joined_Projects)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.User_Id)
                ;
            modelBuilder.Entity<UserCategory>()
              .HasOne(c => c.Category)
              .WithMany(c => c.UserCategory)
              .HasForeignKey(c => c.Category_Id)
               .OnDelete(DeleteBehavior.Restrict);
            ;
            modelBuilder.Entity<ProjectUser>()
                .HasOne(p => p.User)
                .WithMany(p => p.Joined_Projects)
                .HasForeignKey(p => p.User_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            ;

            modelBuilder.Entity<UserCategory>()
                .HasOne(u => u.User)
                .WithMany(u => u.Interests)
                .HasForeignKey(u => u.User_Id).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p=> p.User)
                .WithMany(u => u.Created_Projects)
                .HasForeignKey(p => p.User_Id);


            modelBuilder.Entity<Project>()
                .HasOne(p=> p.Category)
                .WithMany(c=> c.Projects)
                .HasForeignKey(p => p.Category_Id);


            modelBuilder.Entity<ProjectUser>()
                .HasOne(p => p.Project)
                .WithMany(p => p.Project_Users)
                .HasForeignKey(p => p.Project_Id)
                .OnDelete(DeleteBehavior.Restrict);
                ;


            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.User)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.Project)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}