namespace ForumEpam2019_Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Parent_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Parent_Id");
            AddForeignKey("dbo.Comments", "Parent_Id", "dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Parent_Id", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "Parent_Id" });
            DropColumn("dbo.Comments", "Parent_Id");
        }
    }
}
