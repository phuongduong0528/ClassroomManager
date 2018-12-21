namespace ClassroomManager.DbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRowThietBiTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ThietBi", "TongSoLuong", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ThietBi", "TongSoLuong");
        }
    }
}
