using System;

namespace Dasigno.Core.Models.StaticModel
{
    public class ErrorModel
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
