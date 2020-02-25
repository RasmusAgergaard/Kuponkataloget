using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kuponkatalog.Models;

namespace Kuponkatalog.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById(string id)
        {
            var user = _appDbContext.Users.FirstOrDefault(u => u.Id == id);
            _appDbContext.Users.Remove(user);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _appDbContext.Users;
        }

        public ApplicationUser GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
