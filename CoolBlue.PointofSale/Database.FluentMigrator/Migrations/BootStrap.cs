using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    //YYYYMMDDHHMM
    [Migration(201903211149)]
    public class BootStrap : Migration
    {
        public override void Down()
        {
            Delete.Table("Customer");
            Delete.Table("Address");
        }

        public override void Up()
        {
            Create.Table("Address").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                                    .WithColumn("FirstName").AsString()
                                    .WithColumn("LastName").AsString()
                                    .WithColumn("Address1").AsString()
                                    .WithColumn("Address2").AsString()
                                    .WithColumn("Country").AsString()
                                    .WithColumn("State").AsString()
                                    .WithColumn("City").AsString()
                                    .WithColumn("MobileNumber").AsString()
                                    .WithColumn("PostalCode").AsString().
                                    WithColumn("CustomerId").AsInt32();

            Create.Table("Customer").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                                   .WithColumn("UserId").AsString()
                                   .WithColumn("RowVersion").AsCustom("TIMESTAMP").NotNullable()
                                   .WithColumn("Password").AsString();

            Create.ForeignKey("FK_dbo.Address.SubmissionId").FromTable("Address").
                InSchema("dbo").ForeignColumns("CustomerId").
                ToTable("Customer").InSchema("dbo").PrimaryColumns("Id");
        }
    }
}
