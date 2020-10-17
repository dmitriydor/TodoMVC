using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<bool> InsertAsync(User user);
        public Task<bool> UpdateAsync(User user);
        public Task<bool> DeleteAsync(string email);
    }
}