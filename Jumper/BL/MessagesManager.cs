using Jumper.DAL;
using Jumper.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.BL
{
    public class MessagesManager
    {
        #region Data Members

        private static MessagesManager m_Instance;

        #endregion

        #region C-tors

        private MessagesManager()
        {
        }

        #endregion

        #region Static Methods

        public static MessagesManager GetInstance()
        {
            if (m_Instance == null)
                m_Instance = new MessagesManager();

            return m_Instance;
        }

        #endregion

        #region Public Methods

        public void CreateMessage(string content, Guid creatorId, float latitude, float longitude, int radius, int duration)
        {
            Message message = createMessageObject(content, creatorId, latitude, longitude, radius, duration);

            MessageRepository.AddMessage(message);

            SendMessage(message);
        }

        public void SendMessage(Message message)
        {
            if (DateTime.Now >= message.ExpirationTime)
            {
                MessageRepository.DeleteMessage(message.Id);
                return;
            }

            foreach (User user in UserRepository.GetUsers())
            {
                if ((AuthorizationManager.GetInstance().IsInRange(user, message)) &&
                    (AuthorizationManager.GetInstance().IsAuthorized(message, user)))
                {
                    GcmManager.GetInstance().PushNotifications(user.Id, message.Content);
                }
            }
        }

        #endregion

        #region Private Methods

        private Message createMessageObject(string content, Guid creatorId, float latitude, float longitude, int radius, int duration)
        {
            Message message = new Message()
            {
                Creator = UserRepository.GetUserById(creatorId),
                Id = Guid.NewGuid(),
                ExpirationTime = DateTime.Now.AddSeconds(duration),
                Radius = radius,
                Location = DbGeography.FromText(String.Format("POINT ({0} {1})", longitude, latitude)),
                Content = content
            };
            return message;
        }

        #endregion
    }
}
