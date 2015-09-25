using System.ServiceProcess;
using System.Web.Http;
using System.Web.Http.SelfHost;

using IBoxCorp.PrinterService;

namespace IBoxCorp.PrinterService
{
    public partial class PrinterService : ServiceBase
    {
        private HttpSelfHostServer server;
        private readonly HttpSelfHostConfiguration config;

        public PrinterService()
        {
            InitializeComponent();

            config = new HttpSelfHostConfiguration(AppConfig.BaseUrl);
            config.MapHttpAttributeRoutes();
        }

        protected override void OnStart(string[] args)
        {
            server = new HttpSelfHostServer(config);
            server.OpenAsync();
        }

        protected override void OnStop()
        {
            server.CloseAsync().Wait();
            server.Dispose();
        }
    }
}
