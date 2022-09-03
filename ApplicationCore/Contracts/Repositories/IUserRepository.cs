using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(String email);
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
    }
}
