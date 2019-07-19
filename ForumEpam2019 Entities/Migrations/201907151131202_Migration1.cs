namespace ForumEpam2019_Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NickName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.AuthorId)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.HashTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        AuthorId = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        HashTag_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.HashTags", t => t.HashTag_Id)
                .Index(t => t.AuthorId)
                .Index(t => t.HashTag_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "HashTag_Id", "dbo.HashTags");
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Posts", new[] { "HashTag_Id" });
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropTable("dbo.Posts");
            DropTable("dbo.HashTags");
            DropTable("dbo.Comments");
            DropTable("dbo.Authors");
        }
    }
}
