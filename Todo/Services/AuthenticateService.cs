using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Todo.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        public Task Authenticate(string email, HttpContext context)
        {
            throw new System.NotImplementedException();
        }

        public async Task Logout(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}