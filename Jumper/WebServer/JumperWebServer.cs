using Microsoft.Owin.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Owin;
using System.Linq;

namespace Jumper.WebServer
{
    public delegate void RequestHandler(IOwinContext context);

    public class JumperWebServer
    {
        #region Consts

        const string POST_METHOD = "POST";
        const string GET_METHOD = "GET";
        const string PUT_METHOD = "PUT";
        const string DELETE_METHOD = "DELETE";

        const string EXAMPLE_URL = "/example";
        
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

        #region General

        private void intializeResources()
        {
            Startup.Resources = new List<WebResource>();

            // gets.
            Startup.Resources.Add(new WebResource { Path = EXAMPLE_URL, Method = GET_METHOD, Handler = getExample });

            // posts.
            Startup.Resources.Add(new WebResource { Path = EXAMPLE_URL, Method = POST_METHOD, Handler = postExample });

            // puts.
            Startup.Resources.Add(new WebResource { Path = EXAMPLE_URL, Method = PUT_METHOD, Handler = putExample });

            // deletes.
            Startup.Resources.Add(new WebResource { Path = EXAMPLE_URL, Method = DELETE_METHOD, Handler = deleteExample });
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

        private void getExample(Microsoft.Owin.IOwinContext context)
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

        private void postExample(IOwinContext context)
        {
            try
            {
                JObject jsonRequest = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }
        
        #endregion

        #region Put

        private void putExample(IOwinContext context)
        {
            try
            {
                JObject request = getJsonFromRequest(context);
            }
            catch (Exception) { }
        }

        #endregion

        #region Delete

        private void deleteExample(IOwinContext context)
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

        #endregion

        #region To DB
        
        #endregion

        #endregion

        #endregion
    }
}
