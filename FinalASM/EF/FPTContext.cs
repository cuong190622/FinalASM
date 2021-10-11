using FinalASM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalASM.EF
{
    public class FPTContext : DbContext
    {
        public FPTContext() : base("FPTConnection")
        {

        }

        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<StaffEntity> Staffs { get; set; }
        public DbSet<TrainerEntity> Trainers { get; set; }
        public DbSet<TraineeEntity> trainees { get; set; }
        public DbSet<CourseCategoryEntity> courseCategoryEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminEntity>().ToTable("Admin");
            modelBuilder.Entity<CourseEntity>().ToTable("Course");
            modelBuilder.Entity<StaffEntity>().ToTable("Staff");
            modelBuilder.Entity<TrainerEntity>().ToTable("Trainer");
            modelBuilder.Entity<TraineeEntity>().ToTable("Trainee");
            modelBuilder.Entity<CourseCategoryEntity>().ToTable("Category");

            //Admin        
            modelBuilder.Entity<AdminEntity>().Property(c => c.Username).IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            modelBuilder.Entity<AdminEntity>().Property(c => c.Password).IsRequired().HasColumnType("nvarchar").HasMaxLength(25);
            modelBuilder.Entity<AdminEntity>().Property(c => c.Role).HasColumnType("nvarchar").HasMaxLength(20);


            //Staff
            modelBuilder.Entity<StaffEntity>().Property(c => c.Username).IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            modelBuilder.Entity<StaffEntity>().Property(c => c.Password).IsRequired().HasColumnType("nvarchar").HasMaxLength(25);
            modelBuilder.Entity<StaffEntity>().Property(c => c.Role).HasColumnType("nvarchar").HasMaxLength(20);


            //Trainer
            modelBuilder.Entity<TrainerEntity>().Property(c => c.Username).IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            modelBuilder.Entity<TrainerEntity>().Property(c => c.Password).IsRequired().HasColumnType("nvarchar").HasMaxLength(25);
            modelBuilder.Entity<TrainerEntity>().Property(c => c.Role).HasColumnType("nvarchar").HasMaxLength(20);
            modelBuilder.Entity<TrainerEntity>().Property(c => c.Education).HasColumnType("nvarchar").HasMaxLength(40);
            modelBuilder.Entity<TrainerEntity>().Property(c => c.Name).HasColumnType("nvarchar").HasMaxLength(25);
            modelBuilder.Entity<TrainerEntity>().Property(c => c.Type).HasColumnType("nvarchar").HasMaxLength(25);
            modelBuilder.Entity<TrainerEntity>().Property(c => c.WorkingPlace).HasColumnType("nvarchar").HasMaxLength(50);
            modelBuilder.Entity<TrainerEntity>().Property(c => c.Telephone).HasColumnType("nvarchar").HasMaxLength(15);
            modelBuilder.Entity<TrainerEntity>().Property(c => c.Email).HasColumnType("nvarchar").HasMaxLength(35);

            //Trainee
            modelBuilder.Entity<TraineeEntity>().Property(c => c.Username).IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            modelBuilder.Entity<TraineeEntity>().Property(c => c.Password).IsRequired().HasColumnType("nvarchar").HasMaxLength(25);
            modelBuilder.Entity<TraineeEntity>().Property(c => c.Role).HasColumnType("nvarchar").HasMaxLength(20);
            modelBuilder.Entity<TraineeEntity>().Property(c => c.Name).HasColumnType("nvarchar").HasMaxLength(25);
            modelBuilder.Entity<TraineeEntity>().Property(c => c.ProgrammingLanguage).HasColumnType("nvarchar").HasMaxLength(20);
            modelBuilder.Entity<TraineeEntity>().Property(c => c.Toeic).HasColumnType("float");
            modelBuilder.Entity<TraineeEntity>().Property(c => c.Age).HasColumnType("int");
            modelBuilder.Entity<TraineeEntity>().Property(c => c.Education).HasColumnType("nvarchar").HasMaxLength(20);
            modelBuilder.Entity<TraineeEntity>().Property(c => c.Experience).HasMaxLength(50);
            modelBuilder.Entity<TraineeEntity>().Property(c => c.Department).HasMaxLength(50);
            modelBuilder.Entity<TraineeEntity>().Property(c => c.Location).HasMaxLength(50);

            //Course
            modelBuilder.Entity<CourseEntity>().Property(c => c.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            modelBuilder.Entity<CourseEntity>().Property(c => c.Description).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);

            // CourseCategory
            modelBuilder.Entity<CourseCategoryEntity>().Property(c => c.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            modelBuilder.Entity<CourseCategoryEntity>().Property(c => c.Description).IsRequired().HasColumnType("nvarchar").HasMaxLength(25);
        }
    }
}