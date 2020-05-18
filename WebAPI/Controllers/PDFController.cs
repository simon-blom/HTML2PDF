using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/pdf")]
    public class PdfController : ControllerBase
    {
        private IConverter _pdfConverter;

        public PdfController(IConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        [HttpPost]
        [Produces("application/pdf")]
        public IActionResult Create([FromBody]HtmlSourceModel model)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    PaperSize = model.PdfSettings.PaperKind,
                    Orientation = model.PdfSettings.Orientation
                }
            };

            doc.Objects.Add(new ObjectSettings
            {
                HtmlContent = model.Html,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                PagesCount = true
            });

            var pdf = _pdfConverter.Convert(doc);

            return new FileContentResult(pdf, "application/pdf");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var settings = new PdfSettings();
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    PaperSize = settings.PaperKind,
                    Orientation = settings.Orientation
                }
            };

            doc.Objects.Add(new ObjectSettings
            {
                HtmlContent = "<html><body><h1 style='color: #f00;'>Hello world!</h1></body></html>",
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                PagesCount = true
            });

            var pdf = _pdfConverter.Convert(doc);

            return new FileContentResult(pdf, "application/pdf");
        }



    }
}
