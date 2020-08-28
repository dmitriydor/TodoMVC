using System.ComponentModel.DataAnnotations;

namespace Todo.ViewModel
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Firstname not specified")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname not specified")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email not specified")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not correct")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Passwordl not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password not specified")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}