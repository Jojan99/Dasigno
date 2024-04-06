using Dasigno.Core.Helpers;
using Dasigno.Core.Managers;
using Dasigno.Core.Models.StaticModel;
using Dasigno.Core.Resources;
using Npgsql;
using NpgsqlTypes;
using System.Threading.Tasks;

namespace Dasigno.Core.Repositories.Implementations
{
    internal class ErrorReporitory : IErrorReporitory
    {
        private readonly IDBContextManager _dbContextManager;

        public ErrorReporitory(IDBContextManager dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }
        public Task<bool> CreateErrorAsync(ErrorModel error)
        {
            var NpgsqlStatement = SqlStatement.SaveError;

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@Source", NpgsqlDbType.Varchar) { Value = error.Source },
        new NpgsqlParameter("@Message", NpgsqlDbType.Varchar) { Value = error.Message },
        new NpgsqlParameter("@MessageDetail", NpgsqlDbType.Text) { Value = error.MessageDetail }
            };

            return _dbContextManager
                .SentenciaAsync(NpgsqlStatement, parameters)
                .UseSqlRetryPolicy();
        }
    }
}
