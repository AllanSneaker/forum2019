namespace ForumEpam2019_Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update11 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "AuthorId_Id", newName: "Author_Id");
            RenameIndex(table: "dbo.Posts", name: "IX_AuthorId_Id", newName: "IX_Author_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_Author_Id", newName: "IX_AuthorId_Id");
            RenameColumn(table: "dbo.Posts", name: "Author_Id", newName: "AuthorId_Id");
        }
    }
}
