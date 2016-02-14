using Exact.Criccard.CricAPI.App_Start;
using Exact.Criccard.CricAPI.Configuration;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Exact.Criccard.CricAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            StructuremapWebApi.Start();

            /// Database Initialize
            Domain.Entities.CriccardModelInitializer.Initialize();

            /// JSON Settings
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            /// Logger Setup
            Domain.Logging.Logger.Setup();
            
        }
    }
}
