using System.ComponentModel;

namespace Dasigno.Core.Enumerations
{
    public enum StatusResponseEnum
    {
        [Description("SUCCESS")]
        SUCCESS = 200,

        [Description("ERROR")]
        ERROR = -1,

        [Description("EXCEPTION")]
        EXCEPTION = 500,

        [Description("FORM_VALIDATION")]
        FORM_VALIDATION = 100
    }
}
