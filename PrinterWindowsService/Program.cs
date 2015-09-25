using System.ServiceProcess;

namespace IBoxCorp.PrinterService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new PrinterService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
