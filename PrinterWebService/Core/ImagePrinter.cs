using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace PrinterWebService.Core
{
    internal class ImagePrinter
    {
        private string filePath;

        public ImagePrinter(string filePath)
        {
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