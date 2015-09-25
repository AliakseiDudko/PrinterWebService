using System;
using System.IO;
using System.Runtime.InteropServices;

namespace IBoxCorp.PrinterService
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

        [DllImport("shimgvw.dll", CharSet = CharSet.Unicode)]
        private static extern int ImageView_PrintTo(IntPtr hwnd, IntPtr hInst, string lpszCmdLine, int nShowCmd);

        public void PrintImage()
        {
            if (!PrinterManager.PrinterExists)
            {
                var message = string.Format(@"Printer ""{0}"" was not found.", AppConfig.PrinterName);
                throw new InvalidOperationException(message);
            }

            var commandLine = string.Format(@"/pt ""{0}"" ""{1}""", filePath, AppConfig.PrinterName);
            ImageView_PrintTo(IntPtr.Zero, IntPtr.Zero, commandLine, 0);

            return;
        }
    }
}