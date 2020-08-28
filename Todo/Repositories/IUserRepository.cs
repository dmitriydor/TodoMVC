using System.Linq;
using Todo.Models;

namespace Todo.Repositories
{
    public interface IUserRepository
    {
        public IQueryable<User> Users { get; }
        public bool Create(User user);
        public bool Update(User user);
        public bool Delete(string email);
    }
}