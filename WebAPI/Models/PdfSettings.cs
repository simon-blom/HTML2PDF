using DinkToPdf;

namespace WebAPI.Models
{
    public class PdfSettings
    {
        public PdfSettings()
        {
            Orientation = Orientation.Portrait;
            PaperKind = PaperKind.A4;
        }
        public Orientation Orientation { get; set; }
        public PaperKind PaperKind { get; set; }
    }
}
