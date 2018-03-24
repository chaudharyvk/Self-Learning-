using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
   public static class CoolBlueFluentMigraionRunner
    {
        public static void Run(string connectionString = "" , bool previewOnly = false)
        {

            var connection = string.IsNullOrWhiteSpace(connectionString) ? System.Configuration.ConfigurationManager.ConnectionStrings.OfType<ConnectionStringSettings>().Single().ConnectionString : 
                                                                                connectionString;

            var env = ConfigurationManager.AppSettings["ENVIORNMENT"].ToUpper();

            var targets = new[] { Assembly.GetExecutingAssembly().ManifestModule.Name };

            var announcer = new TextWriterAnnouncer(Console.Out);
            var migrationContext = new RunnerContext(announcer)
            {
                Connection = connection,
                Database = "sqlserver2014",
                Targets = targets,
                PreviewOnly = previewOnly,
                Tags = new[] { env }
            };
            migrationContext.Announcer.Say($"DB got cleared ? {ConfigurationManager.AppSettings["Clear_DB_FIRST"]}");
            DatabaseHelper.CreateIfNotExists(migrationContext.Connection);
            var executor = new TaskExecutor(migrationContext);
            executor.Execute();
        }
    }
}
