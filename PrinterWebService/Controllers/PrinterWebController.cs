using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web.Http;

using IBoxCorp.PrinterWebService.Core;

namespace IBoxCorp.PrinterWebService.Controllers
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
            return PrinterSettings.InstalledPrinters.Cast<string>().ToArray();
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
