using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.DAL.Repositories
{
    public static class ZoneRepository
    {
        public static void AddZone(Zone zone)
        {
            using (var dbContext = new JumperDbContainer())
            {
                dbContext.Zones.Add(zone);
                User user = dbContext.Users.Find(zone.User.Id);
                user.Zones.Add(zone);

                dbContext.SaveChanges();
            }
        }

        public static void DeleteZone (Guid zoneId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                Zone zone = dbContext.Zones.Find(zoneId);
                User user = dbContext.Users.Find(zone.User.Id);
                user.Zones.Remove(zone);
                dbContext.Zones.Remove(zone);
                dbContext.SaveChanges();
            }
        }

        public static ICollection<Zone> GetZonesByUserId(Guid userId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                User user = dbContext.Users.Find(userId);
                return user.Zones.ToList();
            }
        }

        public static void UpdateZone(Zone zone)
        {
            DeleteZone(zone.Id);
            AddZone(zone);
        }
    }
}
