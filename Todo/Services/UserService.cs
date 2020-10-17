using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;
using Todo.Repositories;

namespace Todo.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<bool> InsertAsync(string email, string password)
        {
            var user = CreateUser(email, password);
            return await _userRepository.InsertAsync(user);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            user.Password = GetHash(user.Password);
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteAsync(string email)
        {
            return await _userRepository.DeleteAsync(email);
        }

        private User CreateUser(string email, string password)
        {
            var passwordHash = GetHash(password);
            
            return new User
            {
                Email = email,
                Password = passwordHash,
                RegDate = DateTime.UtcNow
            };
        }

        private string GetHash(string str)
        {
            var bytes = Encoding.Unicode.GetBytes(str);
            var hashBytes = new SHA256CryptoServiceProvider().ComputeHash(bytes);
            var hash = Encoding.Unicode.GetString(hashBytes);
            return hash;
        }
    }
}