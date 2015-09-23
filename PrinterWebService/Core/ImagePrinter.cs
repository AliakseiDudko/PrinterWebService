using System;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace IBoxCorp.PrinterWebService.Core
{
    internal class ImagePrinter
    {
        private string filePath;

        public ImagePrinter(string filePath)
        {
            if (!File.Exists(filePath))
            {
                var message = string.Format("File {0} does not exist.", filePath);
                throw new ArgumentException(message, "filePath");
            }

            this.filePath = filePath;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpszParameters, string lpDirectory, int nShowCmd);

        [DllImport("shimgvw.dll", CharSet = CharSet.Unicode)]
        private static extern int ImageView_PrintTo(IntPtr hwnd, IntPtr hInst, string lpszCmdLine, int nShowCmd);

        public void PrintImage()
        {
            if (!PrinterSettings.InstalledPrinters.Cast<string>().ToArray().Contains(AppConfig.PrinterName))
            {
                var message = string.Format(@"Printer ""{0}"" was not found.", AppConfig.PrinterName);
                throw new InvalidOperationException(message);
            }

            var commandLine = string.Format(@"/pt ""{0}"" ""{1}""", filePath, AppConfig.PrinterName);
            ImageView_PrintTo(IntPtr.Zero, IntPtr.Zero, commandLine, 0);

            //var shellExecuteCommandLine = string.Format(@"shimgvw.dll,ImageView_PrintTo {0}", commandLine);
            //ShellExecute(
            //    IntPtr.Zero,
            //    string.Empty,
            //    "rundll32.exe",
            //    shellExecuteCommandLine,
            //    string.Empty,
            //    0);

            return;
        }
    }
}