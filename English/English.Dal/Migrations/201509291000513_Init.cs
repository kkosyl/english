namespace English.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Excercise",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExcerciseType = c.String(maxLength: 128),
                        Content = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExcerciseType", t => t.ExcerciseType)
                .Index(t => t.ExcerciseType);
            
            CreateTable(
                "dbo.ExcerciseType",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 128),
                        Statement = c.String(),
                        Choices = c.String(),
                    })
                .PrimaryKey(t => t.Type);
            
            CreateTable(
                "dbo.Introduction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExerciseType = c.String(maxLength: 128),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExcerciseType", t => t.ExerciseType)
                .Index(t => t.ExerciseType);
            
            CreateTable(
                "dbo.UserExercise",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExcerciseId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Excercise", t => t.ExcerciseId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ExcerciseId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostReply",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Content = c.String(),
                        IsUseful = c.Boolean(nullable: false),
                        ReplyDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.PostId)
                .Index(t => t.UserId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Content = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        HasNewContent = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.UserId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PostReplyUserVote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostReplyId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        HasVoted = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostReply", t => t.PostReplyId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.PostReplyId)
                .Index(t => t.UserId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserExercise", "UserId", "dbo.User");
            DropForeignKey("dbo.Post", "User_Id", "dbo.User");
            DropForeignKey("dbo.PostReplyUserVote", "User_Id", "dbo.User");
            DropForeignKey("dbo.PostReply", "User_Id", "dbo.User");
            DropForeignKey("dbo.PostReply", "UserId", "dbo.User");
            DropForeignKey("dbo.PostReplyUserVote", "UserId", "dbo.User");
            DropForeignKey("dbo.PostReplyUserVote", "PostReplyId", "dbo.PostReply");
            DropForeignKey("dbo.PostReply", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "UserId", "dbo.User");
            DropForeignKey("dbo.UserExercise", "ExcerciseId", "dbo.Excercise");
            DropForeignKey("dbo.Excercise", "ExcerciseType", "dbo.ExcerciseType");
            DropForeignKey("dbo.Introduction", "ExerciseType", "dbo.ExcerciseType");
            DropIndex("dbo.PostReplyUserVote", new[] { "User_Id" });
            DropIndex("dbo.PostReplyUserVote", new[] { "UserId" });
            DropIndex("dbo.PostReplyUserVote", new[] { "PostReplyId" });
            DropIndex("dbo.Post", new[] { "User_Id" });
            DropIndex("dbo.Post", new[] { "UserId" });
            DropIndex("dbo.PostReply", new[] { "User_Id" });
            DropIndex("dbo.PostReply", new[] { "UserId" });
            DropIndex("dbo.PostReply", new[] { "PostId" });
            DropIndex("dbo.UserExercise", new[] { "UserId" });
            DropIndex("dbo.UserExercise", new[] { "ExcerciseId" });
            DropIndex("dbo.Introduction", new[] { "ExerciseType" });
            DropIndex("dbo.Excercise", new[] { "ExcerciseType" });
            DropTable("dbo.PostReplyUserVote");
            DropTable("dbo.Post");
            DropTable("dbo.PostReply");
            DropTable("dbo.User");
            DropTable("dbo.UserExercise");
            DropTable("dbo.Introduction");
            DropTable("dbo.ExcerciseType");
            DropTable("dbo.Excercise");
        }
    }
}
