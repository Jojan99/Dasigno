using Dasigno.Api.Resources;
using Npgsql;
using System.Configuration;

namespace Dasigno.Api.App_Start
{
    internal  class ScriptConfig
    {
        public void ExecuteCreateTableScript()
        {

            var connectionString = ConfigurationManager.AppSettings["DatabaseCreationConnectionString"];
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    var NpgsqlStatement = SqlStatement.CreateBd;

                    using (var cmd = new NpgsqlCommand(NpgsqlStatement, conn))
                    {
                     cmd.ExecuteNonQuery();
                    }


                    conn.ChangeDatabase("bddasigno");

                    var NpgsqlStatementTable = SqlStatement.CreateTableUser;
                    var NpgsqlStatementTableError = SqlStatement.CreateTableError;

                    using (var cmd = new NpgsqlCommand(NpgsqlStatementTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = new NpgsqlCommand(NpgsqlStatementTableError, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (PostgresException ex)
                {
                    if (ex.SqlState != "42P04")
                    {
                        throw;
                    }
                }


            }

        }
    }
}