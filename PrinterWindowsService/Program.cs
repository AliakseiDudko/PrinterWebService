using System.ServiceProcess;

namespace IBoxCorp.PrinterWindowsService
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
