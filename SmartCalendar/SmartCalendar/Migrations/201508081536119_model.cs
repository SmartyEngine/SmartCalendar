namespace SmartCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Events", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Events", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
