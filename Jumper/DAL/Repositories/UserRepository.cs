using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.DAL.Repositories
{
    public static class UserRepository
    {
        public static void DeleteUser(Guid userId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                User user = dbContext.Users.Find(userId);
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        public static void AddUser(User user)
        {
            using (var dbContext = new JumperDbContainer())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }

        public static void UpdateUserLocation(Guid userId, DbGeography location)
        {
            using (var dbContext = new JumperDbContainer())
            {
                dbContext.Users.Find(userId).Location = location;
                dbContext.SaveChanges();
            }
        }

        public static ICollection<User> GetUsers()
        {
            using (var dbContext = new JumperDbContainer())
            {
                return dbContext.Users.ToList();
            }
        }

        public static User GetUserById(Guid userId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                return dbContext.Users.Find(userId);
            }
        }
    }
}
