using Dasigno.Core.Extensions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dasigno.Core.Managers.Implementation
{
    internal class DBContextManager : IDBContextManager
    {
        private readonly NpgsqlConnection _connection;

        public DBContextManager(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public List<T> Get<T>(string query, params NpgsqlParameter[] parameters) where T : new()
        {
            NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            command.Parameters.AddRange(parameters);
            NpgsqlDataReader reader = command.ExecuteReader();
            List<T> result = new List<T>();
            while (reader.Read())
            {
                T item = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(reader.GetName(i));
                    if (propertyInfo != null && !reader.IsDBNull(i))
                    {
                        propertyInfo.SetValue(item, reader.GetValue(i));
                    }
                }
                result.Add(item);
            }
            reader.Close();
            return result;
        }
        public async Task<List<T>> GetAsync<T>(string query, params NpgsqlParameter[] parameters) where T : new()
        {
            NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            command.Parameters.AddRange(parameters);
            NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            List<T> result = new List<T>();
            while (await reader.ReadAsync())
            {
                T item = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(reader.GetName(i));
                    if (propertyInfo != null && !reader.IsDBNull(i))
                    {
                        propertyInfo.SetValue(item, reader.GetValue(i));
                    }
                }
                result.Add(item);
            }
            reader.Close();
            return result;
        }
        public T GetSingle<T>(string query, params NpgsqlParameter[] parameters) where T : new()
        {
            NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            command.Parameters.AddRange(parameters);
            NpgsqlDataReader reader = command.ExecuteReader();
            T result = default;
            if (reader.HasRows && reader.Read())
            {
                result = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(reader.GetName(i));
                    if (propertyInfo != null && !reader.IsDBNull(i))
                    {
                        propertyInfo.SetValue(result, reader.GetValue(i));
                    }
                }
            }
            reader.Close();
            return result;
        }
        public async Task<T> GetSingleAsync<T>(string query, params NpgsqlParameter[] parameters) where T : new()
        {
            NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            command.Parameters.AddRange(parameters);
            NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            T result = default;
            if (reader.HasRows && await reader.ReadAsync())
            {
                result = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(reader.GetName(i));
                    if (propertyInfo != null && !reader.IsDBNull(i))
                    {
                        propertyInfo.SetValue(result, reader.GetValue(i));
                    }
                }
            }
            reader.Close();
            return result;
        }
        public async Task<TValue> GetSingleValueAsync<TValue>(string query, params NpgsqlParameter[] parameters)
        {
            NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            command.Parameters.AddRange(parameters);
            NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            TValue result = default;
            if (reader.HasRows && await reader.ReadAsync())
            {
                if (!reader.IsDBNull(0))
                {
                    result = (TValue)reader.GetValue(0);
                }
            }
            reader.Close();
            return result;
        }
        public bool Sentencia(string query, params NpgsqlParameter[] parameters)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetException());
                return false;
            }
        }

        public async Task<bool> SentenciaAsync(string query, params NpgsqlParameter[] parameters)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                command.Parameters.AddRange(parameters);
                await command.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetException());
                return false;
            }
        }
    }
}
