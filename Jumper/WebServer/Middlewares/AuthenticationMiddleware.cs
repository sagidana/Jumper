using Jumper.BL;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Jumper.WebServer.Middlewares
{
    public class AuthenticationMiddleware : OwinMiddleware
    {
        #region Consts

        private const int STATUS_CODE_FORBIDDEN = 403;
        private const int STATUS_CODE_OK = 200;

        #endregion

        #region C-tors

        public AuthenticationMiddleware(OwinMiddleware next) : base(next) { }

        #endregion

        #region Public Methods

        public async override Task Invoke(IOwinContext context)
        {
            Guid userId = Guid.Parse(context.Request.Headers["JumperUserId"]);

            if (!AuthenticationManager.GetInstance().IsUserValid(userId))
            {
                context.Response.StatusCode = STATUS_CODE_FORBIDDEN;
            }

            context.Response.StatusCode = STATUS_CODE_OK;

            await Next.Invoke(context);
        }

        #endregion
    }
}
