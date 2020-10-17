using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<bool> InsertAsync(string email, string password);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(string email);
    }
}