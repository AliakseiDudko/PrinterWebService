using System;
using System.Configuration;

namespace PrinterWebService.Core
{
    internal static class AppConfig
    {
        public static string ImageLibraryFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["ImageLibraryFolder"];
            }
        }

        public static string PrinterName
        {
            get
            {
                return ConfigurationManager.AppSettings["PrinterName"];
            }
        }

        public static string PrintCommand
        {
            get
            {
                return ConfigurationManager.AppSettings["PrintCommand"];
            }
        }
    }
}