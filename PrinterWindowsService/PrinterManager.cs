using System.Drawing.Printing;
using System.Linq;

namespace IBoxCorp.PrinterService
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
