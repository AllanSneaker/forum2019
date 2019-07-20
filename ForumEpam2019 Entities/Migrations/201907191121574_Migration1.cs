namespace ForumEpam2019_Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.User", newName: "ApplicationUser");
            DropForeignKey("dbo.Posts", "HashTag_Id", "dbo.HashTags");
            DropIndex("dbo.Posts", new[] { "HashTag_Id" });
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PostHashTags",
                c => new
                    {
                        Post_Id = c.Int(nullable: false),
                        HashTag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_Id, t.HashTag_Id })
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .ForeignKey("dbo.HashTags", t => t.HashTag_Id, cascadeDelete: true)
                .Index(t => t.Post_Id)
                .Index(t => t.HashTag_Id);
            
            AddColumn("dbo.Posts", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "User_Id");
            AddForeignKey("dbo.Posts", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Posts", "HashTag_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "HashTag_Id", c => c.Int());
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.PostHashTags", "HashTag_Id", "dbo.HashTags");
            DropForeignKey("dbo.PostHashTags", "Post_Id", "dbo.Posts");
            DropIndex("dbo.PostHashTags", new[] { "HashTag_Id" });
            DropIndex("dbo.PostHashTags", new[] { "Post_Id" });
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropColumn("dbo.Posts", "User_Id");
            DropTable("dbo.PostHashTags");
            DropTable("dbo.Users");
            CreateIndex("dbo.Posts", "HashTag_Id");
            AddForeignKey("dbo.Posts", "HashTag_Id", "dbo.HashTags", "Id");
            RenameTable(name: "dbo.ApplicationUser", newName: "User");
        }
    }
}
