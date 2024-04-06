using Dasigno.Core.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Dasigno.Core.Requests
{
    public class UserCreateRequest
    {
        [Required(ErrorMessage = Constants.Requests.PLEASE_ENTER_FIRSTNAME)]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = Constants.Requests.NO_NUMBERS)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(50)]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = Constants.Requests.NO_NUMBERS)]
        public string SecondName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = Constants.Requests.PLEASE_ENTER_SURNAME), MaxLength(50)]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = Constants.Requests.NO_NUMBERS)]
        public string Surname { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(50)]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = Constants.Requests.NO_NUMBERS)]
        public string SecondSurname { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = Constants.Requests.PLEASE_ENTER_BIRTHSURNAME)]
        public string BirthdayDate { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = Constants.Requests.METHOD_CUSTOM_VALIDATION_GREATER_TO_ZERO)]
        public decimal Salary { get; set; }

    }
}
