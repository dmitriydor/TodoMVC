using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
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

        public IQueryable<User> Users => _context.Users;

        public bool Create(User user)
        {
            var userDb = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userDb == null)
            {
                _context.Add(user);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(string email)
        {
            var userDb = _context.Users.FirstOrDefault(u => u.Email == email);
            if (userDb != null)
            {
                _context.Users.Remove(userDb);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(User user)
        {
            var userDb = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userDb != null)
            {
                userDb.About = user.About;
                userDb.DateOfBirth = user.DateOfBirth;
                userDb.Firstname = user.Firstname;
                userDb.Lastname = user.Lastname;
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}