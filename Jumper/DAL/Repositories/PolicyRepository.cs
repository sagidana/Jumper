using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.DAL.Repositories
{
    public static class PolicyRepository
    {
        public static void DeletePolicy(Guid policyId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                Policy policy = dbContext.Policies.Find(policyId);
                User user = dbContext.Users.Find(policy.User.Id);
                user.Policies.Remove(policy);
                dbContext.Policies.Remove(policy);

                dbContext.SaveChanges();
            }
        }

        public static void AddPolicy(Policy policy)
        {
            using (var dbContext = new JumperDbContainer())
            {
                dbContext.Policies.Add(policy);
                User user = dbContext.Users.Find(policy.User.Id);
                user.Policies.Add(policy);

                dbContext.SaveChanges();
            }
        }

        public static ICollection<Policy> GetPoliciesByUserId(Guid userId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                return dbContext.Users.Find(userId).Policies.ToList();
            }
        }
    }
}
