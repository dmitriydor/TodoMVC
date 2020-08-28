using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Todo.Models;

namespace Todo.Services
{
    public interface IUserRepository
    {
        public IQueryable<User> Users { get; }
        public bool Create(User user);
        public bool Update(User user);
        public bool Delete(string email);
        public Task Authenticate(string email, HttpContext context);
    }
}