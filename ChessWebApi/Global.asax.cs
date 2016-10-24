using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ChessWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToLower().Equals("options"))
            {
                AddHeadersToReponse();
                Context.Response.StatusCode = 200;
                Context.Response.End();
                return;
            }

            if (Context.Request.Path.ToLower().Contains("odata/") ||
                Context.Request.Path.ToLower().Contains("api/"))
            {
                AddHeadersToReponse();
            }
        }

        private void AddHeadersToReponse()
        {
            Context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            Context.Response.AddHeader("Access-Control-Allow-Headers", "*, Content-Type, Authorization");
            Context.Response.AddHeader("Access-Control-Allow-Methods", "*, DELETE");
        }
    }
}
