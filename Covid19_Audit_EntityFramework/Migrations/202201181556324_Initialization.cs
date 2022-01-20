namespace Covid19_Audit_EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Covid19_Audit.AuditCodes",
                c => new
                    {
                        AuditCodeId = c.Int(nullable: false, identity: true),
                        AuditCodeText = c.String(),
                    })
                .PrimaryKey(t => t.AuditCodeId);
            
            CreateTable(
                "Covid19_Audit.FocusAreas",
                c => new
                    {
                        FocusAreaId = c.Int(nullable: false, identity: true),
                        AreaName = c.String(),
                    })
                .PrimaryKey(t => t.FocusAreaId);
            
            CreateTable(
                "Covid19_Audit.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "Covid19_Audit.AuditorLogs",
                c => new
                    {
                        AuditorLogId = c.Int(nullable: false, identity: true),
                        DateAudit = c.DateTime(nullable: false),
                        AuditorBadgeId = c.String(),
                        AuditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuditorLogId)
                .ForeignKey("Covid19_Audit.Audits", t => t.AuditId, cascadeDelete: true)
                .Index(t => t.AuditId);
            
            CreateTable(
                "Covid19_Audit.Audits",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        AuditDate = c.DateTime(nullable: false),
                        Auditor = c.String(),
                        AuditorPartner1 = c.String(),
                        AuditorPartner2 = c.String(),
                        AuditCodeText = c.String(),
                        Location = c.String(),
                        SubmittedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId);
            
            CreateTable(
                "Covid19_Audit.CheckLists",
                c => new
                    {
                        ChecklistId = c.Int(nullable: false, identity: true),
                        FocusAreaText = c.String(),
                        QuestionText = c.String(),
                        Result = c.Boolean(nullable: false),
                        Category = c.String(),
                        Remark = c.String(),
                        UploadedFile = c.String(),
                        AuditId = c.Int(nullable: false),
                        Audit_TransactionId = c.Int(),
                    })
                .PrimaryKey(t => t.ChecklistId)
                .ForeignKey("Covid19_Audit.Audits", t => t.Audit_TransactionId)
                .Index(t => t.Audit_TransactionId);
            
            CreateTable(
                "Covid19_Audit.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        FeedbackContent = c.String(),
                        FocusArea = c.String(),
                        Category = c.String(),
                        UploadedFile = c.String(),
                        AuditId = c.Int(nullable: false),
                        Audit_TransactionId = c.Int(),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("Covid19_Audit.Audits", t => t.Audit_TransactionId)
                .Index(t => t.Audit_TransactionId);
            
            CreateTable(
                "Covid19_Audit.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        BadgeId = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "Covid19_Audit.FocusAreaAuditCodes",
                c => new
                    {
                        FocusArea_FocusAreaId = c.Int(nullable: false),
                        AuditCode_AuditCodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FocusArea_FocusAreaId, t.AuditCode_AuditCodeId })
                .ForeignKey("Covid19_Audit.FocusAreas", t => t.FocusArea_FocusAreaId, cascadeDelete: true)
                .ForeignKey("Covid19_Audit.AuditCodes", t => t.AuditCode_AuditCodeId, cascadeDelete: true)
                .Index(t => t.FocusArea_FocusAreaId)
                .Index(t => t.AuditCode_AuditCodeId);
            
            CreateTable(
                "Covid19_Audit.QuestionFocusAreas",
                c => new
                    {
                        Question_QuestionId = c.Int(nullable: false),
                        FocusArea_FocusAreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_QuestionId, t.FocusArea_FocusAreaId })
                .ForeignKey("Covid19_Audit.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .ForeignKey("Covid19_Audit.FocusAreas", t => t.FocusArea_FocusAreaId, cascadeDelete: true)
                .Index(t => t.Question_QuestionId)
                .Index(t => t.FocusArea_FocusAreaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Covid19_Audit.Feedbacks", "Audit_TransactionId", "Covid19_Audit.Audits");
            DropForeignKey("Covid19_Audit.CheckLists", "Audit_TransactionId", "Covid19_Audit.Audits");
            DropForeignKey("Covid19_Audit.AuditorLogs", "AuditId", "Covid19_Audit.Audits");
            DropForeignKey("Covid19_Audit.QuestionFocusAreas", "FocusArea_FocusAreaId", "Covid19_Audit.FocusAreas");
            DropForeignKey("Covid19_Audit.QuestionFocusAreas", "Question_QuestionId", "Covid19_Audit.Questions");
            DropForeignKey("Covid19_Audit.FocusAreaAuditCodes", "AuditCode_AuditCodeId", "Covid19_Audit.AuditCodes");
            DropForeignKey("Covid19_Audit.FocusAreaAuditCodes", "FocusArea_FocusAreaId", "Covid19_Audit.FocusAreas");
            DropIndex("Covid19_Audit.QuestionFocusAreas", new[] { "FocusArea_FocusAreaId" });
            DropIndex("Covid19_Audit.QuestionFocusAreas", new[] { "Question_QuestionId" });
            DropIndex("Covid19_Audit.FocusAreaAuditCodes", new[] { "AuditCode_AuditCodeId" });
            DropIndex("Covid19_Audit.FocusAreaAuditCodes", new[] { "FocusArea_FocusAreaId" });
            DropIndex("Covid19_Audit.Feedbacks", new[] { "Audit_TransactionId" });
            DropIndex("Covid19_Audit.CheckLists", new[] { "Audit_TransactionId" });
            DropIndex("Covid19_Audit.AuditorLogs", new[] { "AuditId" });
            DropTable("Covid19_Audit.QuestionFocusAreas");
            DropTable("Covid19_Audit.FocusAreaAuditCodes");
            DropTable("Covid19_Audit.Users");
            DropTable("Covid19_Audit.Feedbacks");
            DropTable("Covid19_Audit.CheckLists");
            DropTable("Covid19_Audit.Audits");
            DropTable("Covid19_Audit.AuditorLogs");
            DropTable("Covid19_Audit.Questions");
            DropTable("Covid19_Audit.FocusAreas");
            DropTable("Covid19_Audit.AuditCodes");
        }
    }
}
