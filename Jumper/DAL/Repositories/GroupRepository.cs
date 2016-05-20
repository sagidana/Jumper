using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.DAL.Repositories
{
    public static class GroupRepository
    {
        public static void AddGroup(Group group)
        {
            using (var dbContext = new JumperDbContainer())
            {
                dbContext.Groups.Add(group);

                foreach (User user in group.Users)
                    user.Groups.Add(group);

                foreach (Group innerGroup in group.IncludedGroups)
                    innerGroup.InGroups.Add(group);

                dbContext.SaveChanges();
            }
        }

        public static void DeleteGroup(Guid groupId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                Group group = dbContext.Groups.Find(groupId);

                foreach (User user in group.Users)
                    user.Groups.Remove(group);

                foreach (Group innerGroup in group.IncludedGroups)
                    innerGroup.InGroups.Remove(group);

                dbContext.Groups.Remove(group);

                dbContext.SaveChanges();
            }
        }

        public static void AddGroupToGroup(Guid toAdd, Guid addTo)
        {
            using (var dbContext = new JumperDbContainer())
            {
                Group groupToAdd = dbContext.Groups.Find(toAdd);
                Group addToGroup = dbContext.Groups.Find(addTo);

                groupToAdd.InGroups.Add(addToGroup);
                addToGroup.IncludedGroups.Add(groupToAdd);

                dbContext.SaveChanges();
            }
        }

        public static void AddUserToGroup(Guid userId, Guid groupId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                Group group = dbContext.Groups.Find(groupId);
                User user = dbContext.Users.Find(userId);

                group.Users.Add(user);
                user.Groups.Add(group);

                dbContext.SaveChanges();
            }
        }

        public static ICollection<Group> GetGroupsByUserId(Guid userId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                User user = dbContext.Users.Find(userId);
                return user.Groups.ToList();
            }
        }

        public static ICollection<Group> GetGroupsByGroupId(Guid groupId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                Group group = dbContext.Groups.Find(groupId);
                return group.IncludedGroups.ToList();
            }
        }
    }
}
