namespace Dasigno.Core.Models.StaticModel
{
    public class FormatResponseModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public FormatResponseModel() { }

        public FormatResponseModel(int status, string message)
        {
            Status = status;
            Message = message;
        }

        public FormatResponseModel(int status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

    }
}
