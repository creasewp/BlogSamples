using System.Web.Http;
using System.Web.Routing;

namespace MobileService1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register();
        }
    }
}