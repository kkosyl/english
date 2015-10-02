namespace English.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercise",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExerciseType = c.String(maxLength: 128),
                        Content = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExerciseType", t => t.ExerciseType)
                .Index(t => t.ExerciseType);
            
            CreateTable(
                "dbo.ExerciseType",
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
                .ForeignKey("dbo.ExerciseType", t => t.ExerciseType)
                .Index(t => t.ExerciseType);
            
            CreateTable(
                "dbo.UserExercise",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExerciseId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercise", t => t.ExerciseId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ExerciseId)
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
                        ReplyDate = c.DateTime(nullable: false),
                        Useful = c.Int(nullable: false),
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
                        Topic = c.String(),
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
            DropForeignKey("dbo.UserExercise", "ExerciseId", "dbo.Exercise");
            DropForeignKey("dbo.Exercise", "ExerciseType", "dbo.ExerciseType");
            DropForeignKey("dbo.Introduction", "ExerciseType", "dbo.ExerciseType");
            DropIndex("dbo.PostReplyUserVote", new[] { "User_Id" });
            DropIndex("dbo.PostReplyUserVote", new[] { "UserId" });
            DropIndex("dbo.PostReplyUserVote", new[] { "PostReplyId" });
            DropIndex("dbo.Post", new[] { "User_Id" });
            DropIndex("dbo.Post", new[] { "UserId" });
            DropIndex("dbo.PostReply", new[] { "User_Id" });
            DropIndex("dbo.PostReply", new[] { "UserId" });
            DropIndex("dbo.PostReply", new[] { "PostId" });
            DropIndex("dbo.UserExercise", new[] { "UserId" });
            DropIndex("dbo.UserExercise", new[] { "ExerciseId" });
            DropIndex("dbo.Introduction", new[] { "ExerciseType" });
            DropIndex("dbo.Exercise", new[] { "ExerciseType" });
            DropTable("dbo.PostReplyUserVote");
            DropTable("dbo.Post");
            DropTable("dbo.PostReply");
            DropTable("dbo.User");
            DropTable("dbo.UserExercise");
            DropTable("dbo.Introduction");
            DropTable("dbo.ExerciseType");
            DropTable("dbo.Exercise");
        }
    }
}
