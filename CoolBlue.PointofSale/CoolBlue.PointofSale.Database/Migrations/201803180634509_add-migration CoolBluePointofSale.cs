namespace CoolBlue.PointofSale.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationCoolBluePointofSale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "State", c => c.String());
            AddColumn("dbo.Addresses", "LandMark", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "LandMark");
            DropColumn("dbo.Addresses", "State");
        }
    }
}
