using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> InsertAsync(User user)
        {
            var userDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (userDb != null) return false;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string email)
        {
            var userDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (userDb == null) return false;
            _context.Users.Remove(userDb);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var userDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (userDb == null) return false;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}