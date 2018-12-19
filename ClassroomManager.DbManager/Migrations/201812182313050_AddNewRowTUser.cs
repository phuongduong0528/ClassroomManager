namespace ClassroomManager.DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewRowTUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Role");
        }
    }
}
