using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.BL
{
    public class GcmManager
    {
        #region Consts

        const string POST_METHOD = "POST";
        const string JSON_TYPE = "application/json";

        const string GCM_URL = "https://gcm-http.googleapis.com/gcm/send";
        const string GCM_NOTFICATION_TEMPLATE = "{\"data\": {\"message\":\"{{0}}\"}, \"to\":\"{{1}}\"}";
        const string GCM_AUTHORIZATION_TEMPLATE = "Authorization: key=";

        #endregion

        #region Data Members

        private Dictionary<Guid, string> m_RegisteredClients;
        private static GcmManager m_Instance;

        #endregion

        #region Properties

        public string Key { get; set; }

        #endregion

        #region C-tors

        private GcmManager()
        {
            m_RegisteredClients = new Dictionary<Guid, string>();
        }

        #endregion

        #region Static Methods

        public static GcmManager GetInstance()
        {
            if (m_Instance == null)
                m_Instance = new GcmManager();

            return m_Instance;
        }

        #endregion

        #region Public Methods

        public void RegisterClient(Guid userId, string id)
        {
            lock (m_RegisteredClients)
            {
                if (!m_RegisteredClients.ContainsKey(userId))
                    m_RegisteredClients.Add(userId, id);
                else if (m_RegisteredClients[userId] != id)
                    m_RegisteredClients[userId] = id;
            }
        }

        public void PushNotifications(Guid to, string message)
        {
            if (!isUserIdValid(to))
                return ;

            if (!sendMessageToClient(m_RegisteredClients[to], message))
            {
                // TODO: Report error...
            }
        }

        public void PushNotifications(string message)
        {
            foreach (var client in m_RegisteredClients)
                PushNotifications(client.Key, message);
        }

        #endregion

        #region Private Methods

        private bool isUserIdValid(Guid userId)
        {
            return m_RegisteredClients.ContainsKey(userId);
        }

        private bool sendMessageToClient(string to, string message)
        {
            try
            {
                string data = String.Format(GCM_NOTFICATION_TEMPLATE, to, message);

                WebRequest request = createGcmRequest();
                request.GetRequestStream().Write(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetBytes(data).Length);
                using (WebResponse response = request.GetResponse()) { }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private WebRequest createGcmRequest()
        {
            WebRequest request = WebRequest.Create(GCM_URL);

            request.Method = POST_METHOD;
            request.ContentType = JSON_TYPE;
            request.Headers.Add(GCM_AUTHORIZATION_TEMPLATE + Key); // API Key

            return request;
        }

        #endregion
    }
}
