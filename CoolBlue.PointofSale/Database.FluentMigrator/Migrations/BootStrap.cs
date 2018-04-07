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
                                    .WithColumn("FirstName").AsString().Nullable()
                                    .WithColumn("LastName").AsString().Nullable()
                                    .WithColumn("Address1").AsString().Nullable()
                                    .WithColumn("Address2").AsString().Nullable()
                                    .WithColumn("Country").AsString().Nullable()
                                    .WithColumn("State").AsString().Nullable()
                                    .WithColumn("City").AsString().Nullable()
                                    .WithColumn("MobileNumber").AsInt32().Nullable()
                                    .WithColumn("PostalCode").AsInt32().Nullable().
                                     WithColumn("CustomerId").AsInt32().Nullable().
                                     WithColumn("CreatedBy").AsInt32().NotNullable().
                                     WithColumn("UpdatedBy").AsInt32().Nullable().
                                     WithColumn("CreatedDate").AsDate().NotNullable().
                                     WithColumn("UpdatedDate").AsDate().Nullable();

            Create.Table("Customer").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                                   .WithColumn("UserId").AsString()
                                   .WithColumn("RowVersion").AsCustom("TIMESTAMP").NotNullable()
                                   .WithColumn("Password").AsString()
                                   .WithColumn("CreatedBy").AsInt32().NotNullable()
                                   .WithColumn("UpdatedBy").AsInt32().Nullable()
                                   .WithColumn("CreatedDate").AsDate().NotNullable()
                                   .WithColumn("UpdatedDate").AsDate().Nullable();

            Create.Table("Countries").WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                                     .WithColumn("SortName").AsString()
                                     .WithColumn("Name").AsString()
                                     .WithColumn("PhoneCode").AsInt32().NotNullable();

            Create.Table("States").WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                                  .WithColumn("Name").AsString()
                                  .WithColumn("CountryId").AsInt32();


            Create.Table("Cities").WithColumn("Id").AsInt32().PrimaryKey().Identity()                                  
                                  .WithColumn("name").AsString()
                                  .WithColumn("stateid").AsInt32();

            Create.ForeignKey("FK_dbo.Address_CustomerId").FromTable("Address").
                InSchema("dbo").ForeignColumns("CustomerId").
                ToTable("Customer").InSchema("dbo").PrimaryColumns("Id").OnDeleteOrUpdate(System.Data.Rule.Cascade);


            Create.Table("CustomerEvent").WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                                         .WithColumn("BeforeChangeStatusId").AsInt32().NotNullable()
                                         .WithColumn("AfterChangeStatusId").AsInt32().NotNullable()
                                         .WithColumn("EventDate").AsDateTime().NotNullable()
                                         .WithColumn("ModifyUserId").AsInt32().NotNullable()
                                         .WithColumn("CustomerId").AsInt32().NotNullable()                                        
                                         .WithColumn("CustomerEventTypeId").AsInt32().NotNullable();


            Create.Table("CustomerEventType").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                                 .WithColumn("Name").AsString()
                                 .WithColumn("Description").AsInt32();

            Create.Table("CustomerStatus").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                                 .WithColumn("Name").AsString()
                                 .WithColumn("Description").AsInt32();

        }                                    
    }
}
