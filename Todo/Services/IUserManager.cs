using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public interface IUserManager
    {
        public IQueryable<User> Users { get;}
        public bool Create(User user);
        public bool Update(User user);
        public bool Delete(string email);
        public Task Authenticate(string email, Microsoft.AspNetCore.Http.HttpContext context);
    }
}
