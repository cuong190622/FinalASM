namespace FinalASM.EF.FPTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false, maxLength: 25),
                        Role = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Category = c.String(),
                        Description = c.String(nullable: false, maxLength: 200),
                        CourseCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CourseCategory_Id)
                .Index(t => t.CourseCategory_Id);
            
            CreateTable(
                "dbo.Trainee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false, maxLength: 25),
                        Role = c.String(maxLength: 20),
                        Name = c.String(maxLength: 25),
                        Education = c.String(maxLength: 20),
                        Age = c.Int(nullable: false),
                        DoB = c.DateTime(nullable: false),
                        ProgrammingLanguage = c.String(maxLength: 20),
                        Toeic = c.Double(nullable: false),
                        Experience = c.String(maxLength: 50),
                        Department = c.String(maxLength: 50),
                        Location = c.String(maxLength: 50),
                        CourseAssignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false, maxLength: 25),
                        Role = c.String(maxLength: 20),
                        Name = c.String(maxLength: 25),
                        Type = c.String(maxLength: 25),
                        Education = c.String(maxLength: 40),
                        WorkingPlace = c.String(maxLength: 50),
                        Telephone = c.String(maxLength: 15),
                        Email = c.String(maxLength: 35),
                        CourseAssignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false, maxLength: 25),
                        Role = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TraineeEntityCourseEntities",
                c => new
                    {
                        TraineeEntity_Id = c.Int(nullable: false),
                        CourseEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TraineeEntity_Id, t.CourseEntity_Id })
                .ForeignKey("dbo.Trainee", t => t.TraineeEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.CourseEntity_Id, cascadeDelete: true)
                .Index(t => t.TraineeEntity_Id)
                .Index(t => t.CourseEntity_Id);
            
            CreateTable(
                "dbo.TrainerEntityCourseEntities",
                c => new
                    {
                        TrainerEntity_Id = c.Int(nullable: false),
                        CourseEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrainerEntity_Id, t.CourseEntity_Id })
                .ForeignKey("dbo.Trainer", t => t.TrainerEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.CourseEntity_Id, cascadeDelete: true)
                .Index(t => t.TrainerEntity_Id)
                .Index(t => t.CourseEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerEntityCourseEntities", "CourseEntity_Id", "dbo.Course");
            DropForeignKey("dbo.TrainerEntityCourseEntities", "TrainerEntity_Id", "dbo.Trainer");
            DropForeignKey("dbo.TraineeEntityCourseEntities", "CourseEntity_Id", "dbo.Course");
            DropForeignKey("dbo.TraineeEntityCourseEntities", "TraineeEntity_Id", "dbo.Trainee");
            DropForeignKey("dbo.Course", "CourseCategory_Id", "dbo.Category");
            DropIndex("dbo.TrainerEntityCourseEntities", new[] { "CourseEntity_Id" });
            DropIndex("dbo.TrainerEntityCourseEntities", new[] { "TrainerEntity_Id" });
            DropIndex("dbo.TraineeEntityCourseEntities", new[] { "CourseEntity_Id" });
            DropIndex("dbo.TraineeEntityCourseEntities", new[] { "TraineeEntity_Id" });
            DropIndex("dbo.Course", new[] { "CourseCategory_Id" });
            DropTable("dbo.TrainerEntityCourseEntities");
            DropTable("dbo.TraineeEntityCourseEntities");
            DropTable("dbo.Staff");
            DropTable("dbo.Trainer");
            DropTable("dbo.Trainee");
            DropTable("dbo.Course");
            DropTable("dbo.Category");
            DropTable("dbo.Admin");
        }
    }
}
