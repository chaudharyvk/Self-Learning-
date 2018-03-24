using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
  public  class Program
    {
        static void Main(string[] args)
        {
            var clearDBCOnfigEntry = ConfigurationManager.AppSettings["Clear_DB_FIRST"];

            if(clearDBCOnfigEntry!=null && bool.Parse(clearDBCOnfigEntry))
            {
                new DBMigrator(ConfigurationManager.ConnectionStrings["CoolBluePointofSale"].ConnectionString, ConfigurationManager.AppSettings["ENVIORNMENT"]?.ToUpper()).MigrateUp();
            }

           
        }
    }
}
