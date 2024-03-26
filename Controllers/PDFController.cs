using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Aspose.Pdf.Forms;
using Aspose.Pdf.Plugins;
using Microsoft.AspNetCore.Mvc;

namespace pdf_creator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PDFController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            Document pdfDocument = new Document();

            // Obtenha a página onde a imagem precisa ser adicionada
            for (int i = 0; i < 3; i++)
            {
                Page page = pdfDocument.Pages.Add();
                page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment($"Essa é a página {i}"));
            }

            var plugin = new PdfHtml();

            var options = new HtmlToPdfOptions();
            // Specify the input and output file paths

            // Add the input and output file paths to the options
            options.AddOutput(new FileDataSource("/Views/PdfReserva.pdf"));

            var resultContainer = plugin.Process(options);

            // var result = resultContainer.ResultCollection[0];

            // Print the result to the console
            Console.WriteLine(resultContainer.ResultCollection);

            pdfDocument.Save("pdfs/document.pdf");

            return NotFound("Não encontrado ok");
        }
    }
}