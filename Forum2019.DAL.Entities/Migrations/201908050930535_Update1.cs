namespace ForumEpam2019_Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Posts", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Comments", new[] { "Account_Id" });
            DropIndex("dbo.Posts", new[] { "Account_Id" });
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Comments", "Author_Id", c => c.Int());
            AddColumn("dbo.Posts", "AuthorId_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Author_Id");
            CreateIndex("dbo.Posts", "AuthorId_Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.Authors", "Id");
            AddForeignKey("dbo.Posts", "AuthorId_Id", "dbo.Authors", "Id");
            DropColumn("dbo.Comments", "Account_Id");
            DropColumn("dbo.Posts", "AccountId");
            DropColumn("dbo.Posts", "Account_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Account_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Posts", "AccountId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Account_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Posts", "AuthorId_Id", "dbo.Authors");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Posts", new[] { "AuthorId_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropColumn("dbo.Posts", "AuthorId_Id");
            DropColumn("dbo.Comments", "Author_Id");
            DropTable("dbo.Authors");
            CreateIndex("dbo.Posts", "Account_Id");
            CreateIndex("dbo.Comments", "Account_Id");
            AddForeignKey("dbo.Posts", "Account_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Comments", "Account_Id", "dbo.Accounts", "Id");
        }
    }
}
