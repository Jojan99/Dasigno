using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dasigno.Core.Managers
{
    public interface IDBContextManager
    {
        List<T> Get<T>(string query, params NpgsqlParameter[] parameters) where T : new();
        Task<List<T>> GetAsync<T>(string query, params NpgsqlParameter[] parameters) where T : new();
        T GetSingle<T>(string query, params NpgsqlParameter[] parameters) where T : new();
        Task<T> GetSingleAsync<T>(string query, params NpgsqlParameter[] parameters) where T : new();
        bool Sentencia(string query, params NpgsqlParameter[] parameters);
        Task<bool> SentenciaAsync(string query, params NpgsqlParameter[] parameters);
        Task<TValue> GetSingleValueAsync<TValue>(string query, params NpgsqlParameter[] parameters);
    }
}
