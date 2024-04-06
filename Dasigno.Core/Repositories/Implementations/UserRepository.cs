using Dasigno.Core.Helpers;
using Dasigno.Core.Managers;
using Dasigno.Core.Models.User;
using Dasigno.Core.Requests;
using Dasigno.Core.Resources;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dasigno.Core.Repositories.Implementations
{
    internal class UserRepository : IUserRepository
    {
        private readonly IDBContextManager _dbContextManager;

        public UserRepository(IDBContextManager dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }

        public async Task<bool> CreateUserAsync(UserCreateRequest user)
        {
            var NpgsqlStatement = SqlStatement.CreateUser;

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
            new NpgsqlParameter("@firstName", NpgsqlDbType.Varchar)
            { Value = user.FirstName, IsNullable = true },

            new NpgsqlParameter("@secondName", NpgsqlDbType.Varchar)
            { Value = user.SecondName, IsNullable = true },

            new NpgsqlParameter("@surname", NpgsqlDbType.Varchar)
            { Value = user.Surname, IsNullable = true },

            new NpgsqlParameter("@secondSurname", NpgsqlDbType.Varchar)
            { Value = user.SecondSurname, IsNullable = true },

            new NpgsqlParameter("@birthdayDate", NpgsqlDbType.Varchar)
            { Value = user.BirthdayDate, IsNullable = true },

            new NpgsqlParameter("@salary", NpgsqlDbType.Integer)
            { Value = user.Salary, IsNullable = true }

        };


            return await _dbContextManager
                .SentenciaAsync(NpgsqlStatement, parameters)
                .UseSqlRetryPolicy();
        }


        public async Task<IEnumerable<UserModel>> GetPageUserAsync(string search, int pageSize, int pageNumber)
        {
            var sqlStatement = SqlStatement.GetPageUser;

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@Search", NpgsqlDbType.Varchar)
        { Value = string.IsNullOrEmpty(search) ? DBNull.Value : (object)search },

        new NpgsqlParameter("@PageSize", NpgsqlDbType.Integer)
        { Value = pageSize },

        new NpgsqlParameter("@PageNumber", NpgsqlDbType.Integer)
        { Value = pageNumber }
            };

            return await _dbContextManager
                .GetAsync<UserModel>(sqlStatement, parameters)
                .UseSqlRetryPolicy();
        }


        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var sqlStatement = SqlStatement.GetUserById;

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {

         new NpgsqlParameter("@id", NpgsqlDbType.Integer)
                { Value = id }
            };

            return await _dbContextManager
             .GetSingleAsync<UserModel>(sqlStatement, parameters)
             .UseSqlRetryPolicy();
        }

        public async Task<bool> UpdateUserByIdAsync(int id,UserCreateRequest user)
        {
            var NpgsqlStatement = SqlStatement.UpdateUser;

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
            new NpgsqlParameter("@firstName", NpgsqlDbType.Varchar)
            { Value = user.FirstName, IsNullable = true },

            new NpgsqlParameter("@secondName", NpgsqlDbType.Varchar)
            { Value = user.SecondName, IsNullable = true },

            new NpgsqlParameter("@surname", NpgsqlDbType.Varchar)
            { Value = user.Surname, IsNullable = true },

            new NpgsqlParameter("@secondSurname", NpgsqlDbType.Varchar)
            { Value = user.SecondSurname, IsNullable = true },

            new NpgsqlParameter("@birthdayDate", NpgsqlDbType.Varchar)
            { Value = user.BirthdayDate, IsNullable = true },

            new NpgsqlParameter("@salary", NpgsqlDbType.Integer)
            { Value = user.Salary, IsNullable = true },

            new NpgsqlParameter("@id", NpgsqlDbType.Integer) { Value = id }

        };


            return await _dbContextManager
                .SentenciaAsync(NpgsqlStatement, parameters)
                .UseSqlRetryPolicy();
        }


        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            var NpgsqlStatement = SqlStatement.DeleteUser;

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {

            new NpgsqlParameter("@id", NpgsqlDbType.Integer) { Value = id }

        };

            return await _dbContextManager
                .SentenciaAsync(NpgsqlStatement, parameters)
                .UseSqlRetryPolicy();
        }
    }
}


