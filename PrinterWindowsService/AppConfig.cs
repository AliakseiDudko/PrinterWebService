using System;
using System.Configuration;

namespace IBoxCorp.PrinterService
{
    internal static class AppConfig
    {
        #region Private Fields

        private static string baseUrl;
        private static string imageLibraryFolder;
        private static string printerName;

        #endregion

        #region Constructors

        static AppConfig()
        {
            baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new InvalidOperationException("BaseUrl is not set in configuration file.");
            }

            imageLibraryFolder = ConfigurationManager.AppSettings["ImageLibraryFolder"];
            if (string.IsNullOrWhiteSpace(imageLibraryFolder))
            {
                throw new InvalidOperationException("ImageLibraryFolder is not set in configuration file.");
            }

            printerName = ConfigurationManager.AppSettings["PrinterName"];
            if (string.IsNullOrWhiteSpace(printerName))
            {
                throw new InvalidOperationException("PrinterName is not set in configuration file.");
            }
        }

        #endregion

        #region Properties

        public static string BaseUrl
        {
            get
            {
                return baseUrl;
            }
        }

        public static string ImageLibraryFolder
        {
            get
            {
                return imageLibraryFolder;
            }
        }

        public static string PrinterName
        {
            get
            {
                return printerName;
            }
        }

        #endregion
    }
}