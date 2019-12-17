using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.ViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email not specified")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not correct")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Passwordl not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
