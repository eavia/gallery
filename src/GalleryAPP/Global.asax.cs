using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;

namespace GalleryAPP
{
    public class Global : System.Web.HttpApplication
    {

        static string _applicationName;

        public static string ApplicationName
        {
            get { return _applicationName; }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            _applicationName=System.Configuration.ConfigurationManager.AppSettings["ApplicationName"];
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~\\errpage.aspx", true);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}