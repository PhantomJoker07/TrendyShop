using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrendyShop.Models
{
    public interface IUserRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetUsers();
        User Add(User user);
        User Update(User user);
        User Delete(int id);
    }
}
