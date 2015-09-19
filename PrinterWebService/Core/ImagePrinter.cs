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

        public void PrintImage()
        {
            var printScriptPath = Path.Combine(Path.GetTempPath(), "Print.bat");
            var printCommand = string.Format(AppConfig.PrintCommand, filePath, AppConfig.PrinterName);
            File.WriteAllText(printScriptPath, printCommand);
            CreateProcessAsUserWrapper.LaunchChildProcess(printScriptPath);
        }
    }
}