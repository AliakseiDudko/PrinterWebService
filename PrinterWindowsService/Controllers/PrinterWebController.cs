using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web.Http;

using IBoxCorp.PrinterService;

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

        [Route("print/{fileName}")]
        [HttpGet]
        public string PrintImage(string fileName)
        {
            var filePath = Path.Combine(AppConfig.ImageLibraryFolder, fileName);
            var imagePrinter = new ImagePrinter(filePath);
            imagePrinter.PrintImage();

            return filePath;
        }

        [Route("finePrint/{fileName}")]
        [HttpGet]
        public string FinePrintImage(string fileName)
        {
            var filePath = Path.Combine(AppConfig.ImageLibraryFolder, fileName);

            var newFileName = string.Format("{0}_Resized{1}", Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
            var newFilePath = Path.Combine(AppConfig.ImageLibraryFolder, newFileName);

            IBoxCorp.PrinterService.ImageConverter.ResizeToRatio(filePath, newFilePath, AppConfig.AspectRatio);

            var imagePrinter = new ImagePrinter(newFilePath);
            imagePrinter.PrintImage();

            return newFilePath;
        }
    }
}
