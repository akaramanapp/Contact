
using ContactApp.Api.Infrastructure;
using ContactApp.Entities.Concrete;
using System;
using System.Web.Http;
using System.Web.Mvc;

namespace ContactApp.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                int _errorCode = System.Runtime.InteropServices.Marshal.GetExceptionCode();
                //Log
                Publisher.SendMessage(new ErrorLog() { ErrorText = ex.Message, ErrorCode = _errorCode, Platform = "Web", CreatedDate = DateTime.Now, });
            }
        }
    }
}
