using System.IO;
using System.Web.Http;

namespace IBoxCorp.PrinterService.Controllers
{
    [RoutePrefix("api")]
    public class PrinterController : ApiController
    {
        [Route("healthCheck")]
        [HttpGet]
        public bool HealthCheck()
        {
            return true;
        }

        [Route("print/{fileName}")]
        [HttpGet]
        public string PrintImage(string fileName)
        {
            var filePath = Path.Combine(AppConfig.ImageLibraryFolder, fileName);
            var imagePrinter = new ImagePrinter(filePath);
            imagePrinter.PrintImage();

            return filePath;
        }
    }
}
