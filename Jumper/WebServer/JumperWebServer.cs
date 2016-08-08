using Microsoft.Owin.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Owin;
using System.Linq;
using Jumper.DAL;
using Jumper.DAL.Repositories;

namespace Jumper.WebServer
{
    public delegate void RequestHandler(IOwinContext context);

    public class JumperWebServer
    {
        #region Consts

        const string METHOD_POST = "POST";
        const string METHOD_GET = "GET";
        const string METHOD_PUT = "PUT";
        const string METHOD_DELETE = "DELETE";

        const string URL_REGISTER = "/register";
        const string URL_MESSAGES = "/messages";
        const string URL_USERS = "/users";
        const string URL_GROUPS = "/groups";
        const string URL_ZONES = "/zones";
        const string URL_POLICIES = "/policies";
        const string URL_GHOSTS = "/ghosts";

        const string JSON_TYPE = "application/json; charset=utf-8;";

        #endregion

        #region Data Members

        IDisposable m_Server;

        #endregion

        #region C-tors

        public JumperWebServer()
        {
            intializeResources();
        }

        #endregion

        #region Public Methods

        public void Start(string url)
        {
            m_Server = WebApp.Start<Startup>(url);
        }

        public void Stop()
        {
            if (m_Server != null)
                m_Server.Dispose();
        }

        #endregion

        #region Private Methods

        #region Generic

        private void intializeResources()
        {
            Startup.Resources = new List<WebResource>();

            // gets.
            Startup.Resources.Add(new WebResource { Path = URL_MESSAGES, Method = METHOD_GET, Handler = getMessages });
            Startup.Resources.Add(new WebResource { Path = URL_USERS, Method = METHOD_GET, Handler = getUsers });
            Startup.Resources.Add(new WebResource { Path = URL_GROUPS, Method = METHOD_GET, Handler = getGroups });
            Startup.Resources.Add(new WebResource { Path = URL_POLICIES, Method = METHOD_GET, Handler = getPolicies });
            Startup.Resources.Add(new WebResource { Path = URL_ZONES, Method = METHOD_GET, Handler = getZones });
            Startup.Resources.Add(new WebResource { Path = URL_GHOSTS, Method = METHOD_GET, Handler = getGhosts });

            // posts.
            Startup.Resources.Add(new WebResource { Path = URL_REGISTER, Method = METHOD_POST, Handler = postRegisters });
            Startup.Resources.Add(new WebResource { Path = URL_MESSAGES, Method = METHOD_POST, Handler = postMessages});
            Startup.Resources.Add(new WebResource { Path = URL_USERS, Method = METHOD_POST, Handler = postUsers });
            Startup.Resources.Add(new WebResource { Path = URL_GROUPS, Method = METHOD_POST, Handler = postGroups });
            Startup.Resources.Add(new WebResource { Path = URL_POLICIES, Method = METHOD_POST, Handler = postPolicies });
            Startup.Resources.Add(new WebResource { Path = URL_ZONES, Method = METHOD_POST, Handler = postZones });
            Startup.Resources.Add(new WebResource { Path = URL_GHOSTS, Method = METHOD_POST, Handler = postGhosts });

            // puts.
            Startup.Resources.Add(new WebResource { Path = URL_REGISTER, Method = METHOD_PUT, Handler = putRegisters });
            Startup.Resources.Add(new WebResource { Path = URL_MESSAGES, Method = METHOD_PUT, Handler = putMessages });
            Startup.Resources.Add(new WebResource { Path = URL_USERS, Method = METHOD_PUT, Handler = putUsers });
            Startup.Resources.Add(new WebResource { Path = URL_GROUPS, Method = METHOD_PUT, Handler = putGroups });
            Startup.Resources.Add(new WebResource { Path = URL_POLICIES, Method = METHOD_PUT, Handler = putPolicies });
            Startup.Resources.Add(new WebResource { Path = URL_ZONES, Method = METHOD_PUT, Handler = putZones });
            Startup.Resources.Add(new WebResource { Path = URL_GHOSTS, Method = METHOD_PUT, Handler = putGhosts });


            // deletes.
            Startup.Resources.Add(new WebResource { Path = URL_REGISTER, Method = METHOD_DELETE, Handler = deleteRegisters });
            Startup.Resources.Add(new WebResource { Path = URL_MESSAGES, Method = METHOD_DELETE, Handler = deleteMessages });
            Startup.Resources.Add(new WebResource { Path = URL_USERS, Method = METHOD_DELETE, Handler = deleteUsers });
            Startup.Resources.Add(new WebResource { Path = URL_GROUPS, Method = METHOD_DELETE, Handler = deleteGroups });
            Startup.Resources.Add(new WebResource { Path = URL_POLICIES, Method = METHOD_DELETE, Handler = deletePolicies });
            Startup.Resources.Add(new WebResource { Path = URL_ZONES, Method = METHOD_DELETE, Handler = deleteZones });
            Startup.Resources.Add(new WebResource { Path = URL_GHOSTS, Method = METHOD_DELETE, Handler = deleteGhosts });

        }

        private void createWebResponse(Microsoft.Owin.IOwinContext context, string dataType, string data)
        {
            context.Response.ContentType = dataType;
            context.Response.Write(data);
        }

        private JObject getJsonFromRequest(Microsoft.Owin.IOwinContext context)
        {
            string body = new StreamReader(context.Request.Body).ReadToEnd();
            JObject jsonRequest = JObject.Parse(body);
            return jsonRequest;
        }

        #endregion

        #region Get

        private void getUsers(Microsoft.Owin.IOwinContext context)
        {
            try
            {
                JArray users = convertDbUsersToJson(UserRepository.GetUsers());

                createWebResponse(context, JSON_TYPE, users.ToString());
            }
            catch (Exception e) { }
        }

        private void getMessages(Microsoft.Owin.IOwinContext context)
        {
            try
            {
                JObject json = new JObject();

                createWebResponse(context, JSON_TYPE, json.ToString());
            }
            catch (Exception) { }
        }

        private void getPolicies(Microsoft.Owin.IOwinContext context)
        {
            try
            {
                JObject json = new JObject();

                createWebResponse(context, JSON_TYPE, json.ToString());
            }
            catch (Exception) { }
        }

        private void getGroups(Microsoft.Owin.IOwinContext context)
        {
            try
            {
                JObject json = new JObject();

                createWebResponse(context, JSON_TYPE, json.ToString());
            }
            catch (Exception) { }
        }

        private void getZones(Microsoft.Owin.IOwinContext context)
        {
            try
            {
                JObject json = new JObject();

                createWebResponse(context, JSON_TYPE, json.ToString());
            }
            catch (Exception) { }
        }

        private void getGhosts(Microsoft.Owin.IOwinContext context)
        {
            try
            {
                JObject json = new JObject();

                createWebResponse(context, JSON_TYPE, json.ToString());
            }
            catch (Exception) { }
        }

        #endregion

        #region Post

        private void postUsers(IOwinContext context)
        {
            try
            {
                JObject jsonRequest = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void postGroups(IOwinContext context)
        {
            try
            {
                JObject jsonRequest = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void postGhosts(IOwinContext context)
        {
            try
            {
                JObject jsonRequest = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void postMessages(IOwinContext context)
        {
            try
            {
                JObject jsonRequest = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void postPolicies(IOwinContext context)
        {
            try
            {
                JObject jsonRequest = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void postZones(IOwinContext context)
        {
            try
            {
                JObject jsonRequest = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void postRegisters(IOwinContext context)
        {
            try
            {
                JObject jsonRequest = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        #endregion

        #region Put

        private void putUsers(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void putGroups(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void putPolicies(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void putMessages(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void putZones(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void putRegisters(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void putGhosts(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        #endregion

        #region Delete

        private void deleteMessages(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void deleteUsers(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void deleteGroups(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void deletePolicies(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void deleteZones(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void deleteGhosts(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        private void deleteRegisters(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        #endregion

        #region Database Converters

        #region To Json

        private JObject convertDbUserToJson(User dbUser)
        {
            JObject user = new JObject();

            user.Add("Id", dbUser.Id);
            user.Add("Name", dbUser.Name);
            user.Add("Location", dbUser.Location.ToString());

            return user;
        }

        private JArray convertDbUsersToJson(IEnumerable<User> dbUsers)
        {
            JArray arrayUsers = new JArray();

            foreach (var dbUser in dbUsers)
                arrayUsers.Add(convertDbUserToJson(dbUser));

            return arrayUsers;
        }

        #endregion

        #region To DB

        #endregion

        #endregion

        #endregion
    }
}
