using Dasigno.Core.Models.StaticModel;
using Dasigno.Core.Requests;
using System.Threading.Tasks;

namespace Dasigno.Core.Domains
{
    public interface IUserDomain : IDomain
    {
        Task<FormatResponseModel> CreateUserAsync(UserCreateRequest user);

        Task<FormatResponseModel> GetPageUserAsync(string search, int pageSize, int pageNumber);

        Task<FormatResponseModel> GetUserByIdAsync(int id);

        Task<FormatResponseModel> UpdateUserByIdAsync(int id, UserCreateRequest user);

        Task<FormatResponseModel> DeleteUserByIdAsync(int id);
    }
}
