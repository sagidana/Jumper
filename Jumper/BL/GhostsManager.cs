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
    public class GhostsManager
    {
        #region Data Members

        private static GhostsManager m_Instance;

        #endregion

        #region C-tors

        private GhostsManager()
        {

        }

        #endregion
        
        #region Static Methods

        public static GhostsManager GetInstance()
        {
            if (m_Instance == null)
                m_Instance = new GhostsManager();

            return m_Instance;
        }

        #endregion

        #region Public Methods

        public void CreateGhost(Guid userId, double latitude, double longitude, int duration)
        {
            Ghost ghost = createGhostObject(userId, latitude, longitude, duration);

            GhostRepository.AddGhost(ghost);
        }

        #endregion
        
        #region Private Methods

        private Ghost createGhostObject(Guid userId, double latitude, double longitude, int duration)
        {
            Ghost ghost = new Ghost()
            {
                Id = Guid.NewGuid(),
                Location = DbGeography.FromText(String.Format("POINT ({0} {1})", longitude, latitude)),
                User = UserRepository.GetUserById(userId),
                ExpirationTime = DateTime.Now.AddSeconds(duration)
            };
            return ghost;
        }

        #endregion

    }
}
