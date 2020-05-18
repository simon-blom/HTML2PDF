namespace WebAPI.Models
{
    public class HtmlSourceModel
    {
        public HtmlSourceModel()
        {
            PdfSettings = new PdfSettings();
        }
        public string Html { get; set; }
        public PdfSettings PdfSettings { get; set; }
    }
}
