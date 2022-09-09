using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Core.Entities;
using Zoan.Core.Repositories;

namespace Zoan.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ZoanDbContext _dbContext;
        

        public UserRepository (ZoanDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public async Task <User> GetByIdAsync(int id)
        {
          return  await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext
                .Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }
    }
}
