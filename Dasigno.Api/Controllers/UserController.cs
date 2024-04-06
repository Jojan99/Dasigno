using Dasigno.Core.Domains;
using Dasigno.Core.Extensions;
using Dasigno.Core.Helpers;
using Dasigno.Core.Models.StaticModel;
using Dasigno.Core.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Dasigno.Api.Controllers
{
    [RoutePrefix("user")]
    public class UserController :BaseController
    {
        [HttpPost]
        [Route("created")]
        public async Task<FormatResponseModel> CreateProfessionAsync(UserCreateRequest user)
        {
            List<ModelError> errors = ErrorValidationRequestHelper.TryValidateModel(user);
            if (errors.Count > 0) return ErrorValidationRequestHelper.BadRequestResponse(errors);
            try
            {
                return await ExecuteDomainServiceAsync<IUserDomain, FormatResponseModel>(s => s.CreateUserAsync(user));
            }
            catch (Exception exception)
            {
                return exception.GetException();
            }
        }

        [HttpGet]
        [Route("page")]
        public async Task<FormatResponseModel> GetPageUserAsync(string search = "", int pageSize = 6, int pageNumber = 1)
        {
            try
            {
                return await ExecuteDomainServiceAsync<IUserDomain, FormatResponseModel>(s => s.GetPageUserAsync(search, pageSize, pageNumber));
            }
            catch (Exception exception)
            {
                return exception.GetException();
            }
        }



        [HttpGet]
        [Route("getById")]
        public async Task<FormatResponseModel> GetUserByIdAsync(int id)
        {
            if (id <= 0) return ErrorValidationRequestHelper.Response(nameof(id));

            try
            {
                return await ExecuteDomainServiceAsync<IUserDomain, FormatResponseModel>(s => s.GetUserByIdAsync(id));
            }
            catch (Exception exception)
            {
                return exception.GetException();
            }
        }


        [HttpPut]
        [Route("putById")]
        public async Task<FormatResponseModel> UpdateUserByIdAsync(int id, UserCreateRequest user)
        {
            List<ModelError> errors = ErrorValidationRequestHelper.TryValidateModel(user);
            if (errors.Count > 0) return ErrorValidationRequestHelper.BadRequestResponse(errors);

            try
            {
                return await ExecuteDomainServiceAsync<IUserDomain, FormatResponseModel>(s => s.UpdateUserByIdAsync(id, user));
            }
            catch (Exception exception)
            {
                return exception.GetException();
            }
        }


        [HttpDelete]
        [Route("deleteById")]
        public async Task<FormatResponseModel> DeleteUserByIdAsync(int id)
        {
            if (id <= 0) return ErrorValidationRequestHelper.Response(nameof(id));

            try
            {
                return await ExecuteDomainServiceAsync<IUserDomain, FormatResponseModel>(s => s.DeleteUserByIdAsync(id));
            }
            catch (Exception exception)
            {
                return exception.GetException();
            }
        }

    }


}