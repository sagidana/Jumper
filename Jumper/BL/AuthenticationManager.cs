using Jumper.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.BL
{
    public class AuthenticationManager
    {
        #region Data Members

        private static AuthenticationManager m_Instance;

        #endregion

        #region C-tors

        private AuthenticationManager()
        {

        }

        #endregion

        #region Static Methods

        public static AuthenticationManager GetInstance()
        {
            if (m_Instance == null)
                m_Instance = new AuthenticationManager();

            return m_Instance;
        }

        #endregion

        #region Public Methods

        public bool IsUserValid(Guid userId)
        {
            return (UserRepository.GetUserById(userId) != null);
        }

        #endregion
    }
}
