using Dasigno.Core.DataProviders;
using Dasigno.Core.Enumerations;
using Dasigno.Core.Extensions;
using Dasigno.Core.Models.StaticModel;
using Dasigno.Core.Models.User;
using Dasigno.Core.Requests;
using System;
using System.Threading.Tasks;

namespace Dasigno.Core.Domains.Implementations
{
    internal class UserDomain :BaseDomain, IUserDomain
    {
        protected IUserDataProvider UserDataProvider { get; }

        public UserDomain(IErrorDataProvider errorDataProvider,
            IUserDataProvider userDataProvider) : base(errorDataProvider)
        {
            UserDataProvider = userDataProvider;
        }


        public async Task<FormatResponseModel> CreateUserAsync(UserCreateRequest user)
        {
            try
            {
                    await UserDataProvider.CreateUserAsync(user);
            }
            catch (Exception exception)
            {
                Response = await InsertedErrorResponse(
                    GetMethodErrorSource(nameof(UserDomain), nameof(CreateUserAsync)),
                    exception.Message,
                    exception);
            }

            return Response;
        }



        public async Task<FormatResponseModel> GetPageUserAsync(string search, int pageSize, int pageNumber)
        {
            try
            {
                Response.Data = await UserDataProvider.GetPageUserAsync(search, pageSize, pageNumber);
            }
            catch (Exception exception)
            {
                Response = await InsertedErrorResponse(
                    GetMethodErrorSource(nameof(UserDomain), nameof(GetPageUserAsync)),
                    exception.Message,
                    exception);
            }

            return Response;
        }


        public async Task<FormatResponseModel> GetUserByIdAsync(int id)
        {
            try
            {
                UserModel user = await UserDataProvider.GetUserByIdAsync(id);

                if (user.HasValue())
                {
                    Response.Data = user;
                }
                else
                {
                    Response.Status = (int)StatusResponseEnum.ERROR;
                    Response.Message = Constants.User.ERROR_DOES_NOT_EXIST_USERS;
                }
            }
            catch (Exception exception)
            {
                Response = await InsertedErrorResponse(
                    GetMethodErrorSource(nameof(UserDomain), nameof(GetUserByIdAsync)),
                    exception.Message,
                    exception);
            }

            return Response;
        }

        public async Task<FormatResponseModel> UpdateUserByIdAsync(int id, UserCreateRequest user)
        {
            try
            {
                UserModel userModel = await UserDataProvider.GetUserByIdAsync(id);

                if (userModel.HasValue())
                {
                    await UserDataProvider.UpdateUserByIdAsync(id,user);

                }
                else
                {
                    Response.Status = (int)StatusResponseEnum.ERROR;
                    Response.Message = Constants.User.ERROR_UPDATE_USER;

                }

            }
            catch (Exception exception)
            {
                Response = await InsertedErrorResponse(
                    GetMethodErrorSource(nameof(UserDomain), nameof(UpdateUserByIdAsync)),
                    exception.Message,
                    exception);
            }

            return Response;
        }


        public async Task<FormatResponseModel> DeleteUserByIdAsync(int id)
        {
            try
            {
                UserModel userModel = await UserDataProvider.GetUserByIdAsync(id);

                if (userModel.HasValue())
                {
                    await UserDataProvider.DeleteUserByIdAsync(id);

                }
                else
                {
                    Response.Status = (int)StatusResponseEnum.ERROR;
                    Response.Message = Constants.User.ERROR_DELETE_USER;
                }

            }
            catch (Exception exception)
            {
                Response = await InsertedErrorResponse(
                    GetMethodErrorSource(nameof(UserDomain), nameof(DeleteUserByIdAsync)),
                    exception.Message,
                    exception);
            }

            return Response;
        }



    }
}
