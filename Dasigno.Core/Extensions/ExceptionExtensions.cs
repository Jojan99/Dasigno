using Dasigno.Core.Enumerations;
using Dasigno.Core.Models.StaticModel;
using System;
using System.Text;

namespace Dasigno.Core.Extensions
{
    public static class ExceptionExtensions
    {
        public static FormatResponseModel GetException(this Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (ex != null)
            {
                stringBuilder.AppendLine($"Message:    {ex.Message}");
                stringBuilder.AppendLine($"Type:       {ex.GetType().FullName}");
                stringBuilder.AppendLine($"HResult:    {ex.HResult}");
                stringBuilder.AppendLine($"Source:     {ex.Source}");
                stringBuilder.AppendLine($"TargetSite: {ex.TargetSite}");

                if (!ex.HelpLink.HasValue())
                {
                    stringBuilder.AppendLine($"HelpLink:   {ex.HelpLink}");
                }

                stringBuilder.AppendLine("StackTrace:");
                stringBuilder.AppendLine(ex.StackTrace);

                if (ex.InnerException != null)
                {
                    stringBuilder.AppendLine("");
                    stringBuilder.AppendLine("InnerException");
                    stringBuilder.AppendLine("");
                    stringBuilder.AppendLine(ex.InnerException.GetInnerException());
                }
            }

            return new FormatResponseModel()
            {
                Status = (int)StatusResponseEnum.FORM_VALIDATION,
                Message = ex.Message,
                Data = stringBuilder.ToString()
            };
        }

        public static string GetInnerException(this Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (ex != null)
            {
                stringBuilder.AppendLine($"Message:    {ex.Message}");
                stringBuilder.AppendLine($"Type:       {ex.GetType().FullName}");
                stringBuilder.AppendLine($"HResult:    {ex.HResult}");
                stringBuilder.AppendLine($"Source:     {ex.Source}");
                stringBuilder.AppendLine($"TargetSite: {ex.TargetSite}");

                if (!ex.HelpLink.HasValue())
                {
                    stringBuilder.AppendLine($"HelpLink:   {ex.HelpLink}");
                }

                stringBuilder.AppendLine("StackTrace:");
                stringBuilder.AppendLine(ex.StackTrace);

                if (ex.InnerException != null)
                {
                    stringBuilder.AppendLine("");
                    stringBuilder.AppendLine("InnerException");
                    stringBuilder.AppendLine("");
                    stringBuilder.AppendLine(ex.InnerException.GetInnerException());
                }
            }

            return stringBuilder.ToString();
        }
    }
}
