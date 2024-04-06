using Dasigno.Core.DataProviders;
using Dasigno.Core.Enumerations;
using Dasigno.Core.Models.StaticModel;
using System.Threading.Tasks;

namespace Dasigno.Core.Domains.Implementations
{
    internal class BaseDomain
    {
        protected FormatResponseModel Response = new FormatResponseModel((int)StatusResponseEnum.SUCCESS, Constants.RESPONSE_MESSAGE_GENERAL);


        protected IErrorDataProvider ErrorDataProvider { get; }

        public BaseDomain(IErrorDataProvider errorDataProvider)
        {
            ErrorDataProvider = errorDataProvider;
        }

        public async Task<bool> CreateErrorAsync(string source, string message, object messageDetail)
        {
            ErrorModel error = new ErrorModel()
            {
                Source = source,
                Message = message,
                MessageDetail = messageDetail.ToString()
            };

            return await ErrorDataProvider.CreateErrorAsync(error);
        }

        public static object RaiseAgentMessage(string source, string message, object messageDetail)
        {
            return new
            {
                Source = source,
                Message = message,
                MessageDetail = messageDetail
            };
        }

        public async Task<FormatResponseModel> InsertedErrorResponse(string source, string message, object messageDetail)
        {
            await CreateErrorAsync(source, message, messageDetail);

            return new FormatResponseModel()
            {
                Message = message,
                Status = (int)StatusResponseEnum.EXCEPTION,
                Data = RaiseAgentMessage(source, message, messageDetail)
            };
        }

        public static string GetMethodErrorSource(string method, string source)
        {
            return $"{method} - {source}";
        }
    }
}
