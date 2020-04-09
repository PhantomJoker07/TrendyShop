using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrendyShop.Models;
using TrendyShop.Data;

namespace TrendyShop.Models
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly EFDbContext context;

        public SQLUserRepository(EFDbContext context)
        {
            this.context = context;
        }

        public User Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            User user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public User GetUser(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }

        public User Update(User user)
        {
            var target = context.Users.Attach(user);
            target.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return user;
        }
    }
}
