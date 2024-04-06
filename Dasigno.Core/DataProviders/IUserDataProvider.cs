using Dasigno.Core.Models.User;
using Dasigno.Core.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dasigno.Core.DataProviders
{
    public interface IUserDataProvider : IDataProvider
    {
        Task<bool> CreateUserAsync(UserCreateRequest user);

        Task<IEnumerable<UserModel>> GetPageUserAsync(string search, int pageSize, int pageNumber);

        Task<UserModel> GetUserByIdAsync(int id);

        Task<bool> UpdateUserByIdAsync(int id, UserCreateRequest user);

        Task<bool> DeleteUserByIdAsync(int id);
    }
}
