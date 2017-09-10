//namespace DomainDrivenDesign.SharedDatabase.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class CustomerInformation : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Addresses",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Address1 = c.String(),
//                        Country = c.String(),
//                        City = c.String(),
//                        PIN = c.Int(nullable: false),
//                        CustomerID = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Customers", t => t.CustomerID)
//                .Index(t => t.CustomerID);
            
//            CreateTable(
//                "dbo.Customers",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        FirstName = c.String(),
//                        RowVersion = c.Binary(),
//                    })
//                .PrimaryKey(t => t.Id);
            
//        }
        
//        public override void Down()
//        {
//            DropForeignKey("dbo.Addresses", "CustomerID", "dbo.Customers");
//            DropIndex("dbo.Addresses", new[] { "CustomerID" });
//            DropTable("dbo.Customers");
//            DropTable("dbo.Addresses");
//        }
//    }
//}
