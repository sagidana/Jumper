using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.DAL.Repositories
{
    public static class MessageRepository
    {
        public static void AddMessage(Message message)
        {
            using (var dbContext = new JumperDbContainer())
            {
                User user = dbContext.Users.Find(message.UserId);

                user.Messages.Add(message);
                dbContext.Messages.Add(message);

                dbContext.SaveChanges();
            }
        }

        public static void DeleteMessage(Guid messageId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                Message message = dbContext.Messages.Find(messageId);
                User user = dbContext.Users.Find(message.UserId);

                user.Messages.Remove(message);
                dbContext.Messages.Remove(message);

                dbContext.SaveChanges();
            }
        }

        public static ICollection<Message> GetMessagesByUserId(Guid userId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                User user = dbContext.Users.Find(userId);
                return user.Messages.ToList();
            }
        }

        public static Message GetMessageById(Guid messageId)
        {
            using (var dbContext = new JumperDbContainer())
            {
                return dbContext.Messages.Find(messageId);
            }
        }
    }
}
