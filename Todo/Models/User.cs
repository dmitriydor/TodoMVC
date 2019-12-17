using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class User
    {
        //может быть лучше добавить id пользователя как ключ
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
