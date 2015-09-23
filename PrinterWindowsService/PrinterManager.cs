using System.Drawing.Printing;
using System.Linq;

using IBoxCorp.PrinterWebService;

namespace IBoxCorp.PrinterWindowsService
{
    internal static class PrinterManager
    {
        public static string[] InstalledPrinters
        {
            get
            {
                return PrinterSettings.InstalledPrinters.Cast<string>().ToArray();
            }
        }

        public static bool PrinterExists
        {
            get
            {
                return InstalledPrinters.Contains(AppConfig.PrinterName);
            }
        }
    }
}
