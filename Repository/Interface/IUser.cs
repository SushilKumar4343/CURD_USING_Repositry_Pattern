using CURD_Using_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURD_Using_Repository.Repository.Interface
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetUsers();

        Task<int> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<bool> UpdateRecode(User user);
        Task<bool> DeleteRecode(int id);
    }
}
