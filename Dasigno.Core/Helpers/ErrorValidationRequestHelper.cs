using Dasigno.Core.Enumerations;
using Dasigno.Core.Models.StaticModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Dasigno.Core.Helpers
{
    public class ErrorValidationRequestHelper
    {
        public static FormatResponseModel Response(string message, int statusCode = (int)StatusResponseEnum.ERROR)
        {
            return new FormatResponseModel()
            {
                Status = statusCode,
                Message = string.Format(Constants.MESSAGE_RESPONSE, message)
            };
        }

        public static FormatResponseModel BadRequestResponse(IEnumerable<ModelError> errors, string message = Constants.ERROR_DEFAULT_MODEL_VALIDATION)
        {
            return new FormatResponseModel()
            {
                Status = (int)StatusResponseEnum.FORM_VALIDATION,
                Message = message,
                Data = errors
            };
        }

        public static List<ModelError> TryValidateModel(object model)
        {
            List<ModelError> error = null;
            if (model != null)
            {
                ModelMetadata metadata = ModelMetadataProviders.Current
                    .GetMetadataForType(() => model, model.GetType());

                var t = new ModelBindingExecutionContext(new HttpContextWrapper(HttpContext.Current), new ModelStateDictionary());

                error = ModelValidator.GetModelValidator(metadata, t)
                    .Validate(null)
                    .Select(x => new ModelError() { Key = x.MemberName, Messages = new List<string>() { x.Message } })
                    .ToList();
            }

            return error;
        }
    }

    public class ModelError
    {
        public string Key { get; set; }
        public List<string> Messages { get; set; }
    }
}
