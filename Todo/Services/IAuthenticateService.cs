using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Todo.Services
{
    public interface IAuthenticateService
    {
        public Task Authenticate(string email, HttpContext context);
        public Task Logout(HttpContext context);
    }
}