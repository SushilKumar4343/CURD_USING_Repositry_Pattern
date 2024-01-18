using CURD_Using_Repository.Data;
using CURD_Using_Repository.Models;
using CURD_Using_Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURD_Using_Repository.Repository.Service
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext context;
        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var data = await context.Users.ToListAsync();
            return data;
        }

        public async Task<int> AddUser(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<User> GetUserById(int id)
        {
            var data = await context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> UpdateRecode(User user)
        {
            bool status = false;
            if(user != null)
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
                status = true;
            }
            return status;
        }

        public async Task<bool> DeleteRecode(int id)
        {
            bool status = false;
            if (id != 0)
            {
                var data = await context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
                context.Users.Remove(data);
                await context.SaveChangesAsync();
                status = true;
            }
            return status;
        }
    }
}
