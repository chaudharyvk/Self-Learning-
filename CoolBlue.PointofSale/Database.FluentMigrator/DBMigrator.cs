using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using System.Reflection;
using System.IO;
using Database;
using System.Data.SqlClient;

namespace Database
{
  public class DBMigrator
    {
        private readonly string _ConnectionString;
        private readonly string _profile;

        public DBMigrator(string connectionString, string profile)
        {
            _ConnectionString = connectionString;
            _profile = profile;
        }

        public string MigrateUp()
        {
            var option = new ProcessorOptions { PreviewOnly = false, Timeout = 0 };
            var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2014ProcessorFactory();
            var assembly = Assembly.GetExecutingAssembly();

            var sb = new StringBuilder();
            var stringwr = new StringWriter(sb);
            var announcer = new TextWriterAnnouncer(stringwr);

            var migrationContext = new RunnerContext(announcer)
            {
                Profile = _profile,
                Tags = new[] { _profile }
            };

            DatabaseHelper.CreateIfNotExists(_ConnectionString);
            var processor = factory.Create(this._ConnectionString, announcer, option);
            var runner = new MigrationRunner(assembly, migrationContext, processor);

            runner.MigrateUp();

            return stringwr.ToString();
         }

        public void  ClearDB()
        {

            var conn = new SqlConnection(_ConnectionString);

            try
            {
                conn.Open();

                var sql = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Database.DeleteAllObjects.sql")).ReadToEnd();

                var commands = sql.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                foreach(var c in commands)
                {
                    var command = conn.CreateCommand();
                    command.CommandText = c;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception ");
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception clsoing DB : " +  ex.Message + "\n" +ex.StackTrace);
                }
            }
        }
    }
}
