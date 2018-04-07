using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Migrations
{
    [Migration(201903260711)]
    public class InsertStaticData : Migration
    {
        public override void Down()
        {
           
        }

        public override void Up()
        {
            Execute.EmbeddedScript("City.sql");
            Execute.EmbeddedScript("Countries.sql");
            Execute.EmbeddedScript("State.sql");
        }
    }
}
