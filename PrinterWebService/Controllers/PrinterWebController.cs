using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web.Http;

using PrinterWebService.Core;

namespace PrinterWebService.Controllers
{
    [RoutePrefix("api")]
    public class PrinterWebController : ApiController
    {
        [Route("healthCheck")]
        [HttpGet]
        public bool HealthCheck()
        {
            return true;
        }

        [Route("printers")]
        [HttpGet]
        public string[] GetAllPrinters()
        {
            var printers = new List<string>();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                printers.Add(printer);
            }

            return printers.ToArray();
        }

        [Route("print/{fileName}")]
        [HttpGet]
        public string PrintDocument(string fileName)
        {
            var filePath = Path.Combine(AppConfig.ImageLibraryFolder, fileName);
            var imagePrinter = new ImagePrinter(filePath);
            imagePrinter.PrintImage();

            return filePath;
        }
    }
}
