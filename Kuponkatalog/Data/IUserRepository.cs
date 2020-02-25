using Kuponkatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kuponkatalog.Data
{
    public interface IUserRepository
    {
        void AddUser(ApplicationUser user);
        IEnumerable<ApplicationUser> GetAllUsers();
        ApplicationUser GetUserById(int id);
        void DeleteUserById(string id);
    }
}
