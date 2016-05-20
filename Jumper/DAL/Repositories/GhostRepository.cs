using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.DAL.Repositories
{
    public static class GhostRepository
    {
        public static void AddGhost(Ghost ghost)
        {
            using (var dbContext = new JumperDbContainer())
            {
                dbContext.Ghosts.Add(ghost);
                User user = dbContext.Users.Find(ghost.User.Id);
                user.Ghosts.Add(ghost);

                dbContext.SaveChanges();
            }
        }

        public static void DeleteGhost(Guid ghostId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                Ghost ghost = dbContext.Ghosts.Find(ghostId);
                User user = dbContext.Users.Find(ghost.User.Id);

                user.Ghosts.Remove(ghost);
                dbContext.Ghosts.Remove(ghost);

                dbContext.SaveChanges();
            }
        }

        public static ICollection<Ghost> GetGhostsByUserId(Guid userId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                User user = dbContext.Users.Find(userId);
                return user.Ghosts.ToList();
            }
        }
    }
}
