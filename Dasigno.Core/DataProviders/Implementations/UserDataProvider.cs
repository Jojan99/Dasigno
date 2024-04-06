using Dasigno.Core.Models.User;
using Dasigno.Core.Repositories;
using Dasigno.Core.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dasigno.Core.DataProviders.Implementations
{
    internal class UserDataProvider : IUserDataProvider
    {
        private IUserRepository UserRepository { get; }

        public UserDataProvider(IUserRepository userRepository
            )
        {
            UserRepository = userRepository;
        }

        public Task<bool> CreateUserAsync(UserCreateRequest user)
        {
            return UserRepository.CreateUserAsync(user);
        }

        public Task<IEnumerable<UserModel>> GetPageUserAsync(string search, int pageSize, int pageNumber)
        {
            return UserRepository.GetPageUserAsync(search, pageSize, pageNumber);
        }

        public Task<UserModel> GetUserByIdAsync(int id)
        {
            return UserRepository.GetUserByIdAsync(id);
        }

        public Task<bool> UpdateUserByIdAsync(int id, UserCreateRequest user)
        {
            return UserRepository.UpdateUserByIdAsync(id, user);
        }

        public Task<bool> DeleteUserByIdAsync(int id)
        {
            return UserRepository.DeleteUserByIdAsync(id);
        }
    }
}
