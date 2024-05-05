using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository.Interfaces;

namespace Tejedor.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TejedorDBContext _dbContext;
        public UserRepository(TejedorDBContext context) 
        {
            _dbContext = context;
        }

        async Task<IEnumerable<User>> IUserRepository.GetUsers()
        {
            return _dbContext.Users;
        }

        async Task<User?> IUserRepository.GetUser(int userID)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.UserID == userID);
        }

        async Task IUserRepository.AddUsers(IEnumerable<User> users)
        {
            _dbContext.Users.AddRange(users);
            await _dbContext.SaveChangesAsync();
        }

        async Task IUserRepository.UpdateUsers(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }

        async Task IUserRepository.DeleteUsers(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }
    }
}
