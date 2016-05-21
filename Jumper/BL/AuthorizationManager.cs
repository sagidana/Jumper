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
    public class AuthorizationManager
    {
        #region Data Members

        private static AuthorizationManager m_Instance;

        #endregion

        #region C-tors

        private AuthorizationManager() { }

        #endregion

        #region Static Methods

        public static AuthorizationManager GetInstance()
        {
            if (m_Instance == null)
                m_Instance = new AuthorizationManager();

            return m_Instance;
        }

        #endregion

        #region Public Methods

        public bool IsAuthorized(Guid userId)
        {
            return (UserRepository.GetUserById(userId) != null);
        }

        public bool IsAuthorized(Guid messageId, Guid userId)
        {
            User user = UserRepository.GetUserById(userId);
            Message message = MessageRepository.GetMessageById(messageId);

            return IsAuthorized(message, user);
        }

        public bool IsAuthorized(Message message, User user)
        {
            foreach (Zone zone in user.Zones)
            {
                if (isInRange(message.Location, message.Radius, zone.Location, zone.Radius))
                {
                    User messageUser = UserRepository.GetUserById(message.UserId);
                    if (isUserAllowed(messageUser, zone.Policy))
                        return true;
                    else
                        return false;
                }
            }

            return true;
        }

        public bool IsInRange(User user, Message message)
        {
            return isInRange(user.Location, message.Location, message.Radius);
        }

        public bool IsInRange(Guid userId, Guid messageId)
        {
            User user = UserRepository.GetUserById(userId);
            Message message = MessageRepository.GetMessageById(messageId);

            return IsInRange(user, message);
        }

        #endregion

        #region Private Methods

        private bool isUserAllowed(User user, Policy policy)
        {
            return isUserInGroup(user, policy.Group);
        }

        private bool isUserInGroup(User user, Group group)
        {
            if (group.Users.Contains(user))
                return true;

            foreach (Group innerGroup in group.IncludedGroups)
                if (isUserInGroup(user, innerGroup))
                    return true;

            return false;
        }

        private bool isInRange(DbGeography first, int firstRadius, DbGeography second, int secondRadius)
        {
            double? distance = first.Distance(second);

            return (distance <= firstRadius + secondRadius);
        }

        private bool isInRange(DbGeography first, DbGeography second, int radius)
        {
            return (first.Distance(second) <= radius);
        }

        #endregion
    }
}
