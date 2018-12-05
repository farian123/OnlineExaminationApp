namespace OnlineExamination.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ans = c.String(),
                        CurrectAns = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WriteQuestion = c.String(),
                        Mark = c.Double(nullable: false),
                        QuestionOrder = c.Int(nullable: false),
                        AnswerTypeId = c.Int(nullable: false),
                        OptionNo = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnswerTypes", t => t.AnswerTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true);
            
            CreateTable(
                "dbo.AnswerTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SingleType = c.Int(nullable: false),
                        MultipleType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamTypeId = c.Int(nullable: false),
                        ExamCode = c.String(),
                        Topic = c.String(),
                        FullMark = c.Double(nullable: false),
                        DHour = c.Int(nullable: false),
                        DMinute = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.ExamTypes", t => t.ExamTypeId, cascadeDelete: true);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        CourseCode = c.String(),
                        Credit = c.Double(nullable: false),
                        CourseDuration = c.Double(nullable: false),
                        Description = c.String(),
                        Tag = c.String(),
                        OrganizationId = c.Int(nullable: false),
                        Fees = c.Double(nullable: false),
                        CourseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true);
            
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchNo = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true);
            
            CreateTable(
                "dbo.BatchParticipants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchId = c.Int(nullable: false),
                        ParticipantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .ForeignKey("dbo.Participants", t => t.ParticipantId, cascadeDelete: true);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParticipantName = c.String(),
                        RegNo = c.String(),
                        ContactNo = c.Int(nullable: false),
                        Email = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        CityId = c.Int(nullable: false),
                        PostCode = c.String(),
                        Profession = c.String(),
                        HighestAcademic = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TraineeName = c.String(),
                        ContactNo = c.Int(nullable: false),
                        Email = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                        Country = c.String(),
                        Lead = c.String(),
                        Image = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id);
            
            CreateTable(
                "dbo.BatchTrainers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BatchId = c.Int(nullable: false),
                        TraineeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .ForeignKey("dbo.Trainees", t => t.TraineeId, cascadeDelete: true);
            
            CreateTable(
                "dbo.CourseTrainers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TraineeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Trainees", t => t.TraineeId, cascadeDelete: true);
            
            CreateTable(
                "dbo.ExamAttends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        ValidAns = c.Int(nullable: false),
                        ParticipantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Participants", t => t.ParticipantId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(),
                        OrganizationCode = c.String(),
                        Address = c.String(),
                        ContactNo = c.Int(nullable: false),
                        About = c.String(),
                        Logo = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExamShedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamDate = c.DateTime(nullable: false),
                        DHour = c.Int(nullable: false),
                        DMinute = c.Int(nullable: false),
                        Exams_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.Exams_Id);
            
            CreateTable(
                "dbo.ExamTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassTest = c.String(),
                        LabTest = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "ExamTypeId", "dbo.ExamTypes");
            DropForeignKey("dbo.ExamShedules", "Exams_Id", "dbo.Exams");
            DropForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ExamAttends", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.ExamAttends", "ParticipantId", "dbo.Participants");
            DropForeignKey("dbo.Trainees", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.CourseTrainers", "TraineeId", "dbo.Trainees");
            DropForeignKey("dbo.CourseTrainers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.BatchTrainers", "TraineeId", "dbo.Trainees");
            DropForeignKey("dbo.BatchTrainers", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Participants", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.BatchParticipants", "ParticipantId", "dbo.Participants");
            DropForeignKey("dbo.BatchParticipants", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Questions", "AnswerTypeId", "dbo.AnswerTypes");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropTable("dbo.Tags");
            DropTable("dbo.ExamTypes");
            DropTable("dbo.ExamShedules");
            DropTable("dbo.Organizations");
            DropTable("dbo.ExamAttends");
            DropTable("dbo.CourseTrainers");
            DropTable("dbo.BatchTrainers");
            DropTable("dbo.Trainees");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Participants");
            DropTable("dbo.BatchParticipants");
            DropTable("dbo.Batches");
            DropTable("dbo.Courses");
            DropTable("dbo.Exams");
            DropTable("dbo.AnswerTypes");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
