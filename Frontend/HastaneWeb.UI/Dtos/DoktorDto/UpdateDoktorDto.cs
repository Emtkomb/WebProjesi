using HastaneWeb.EntityLayer.Concrete;

namespace HastaneWeb.UI.Dtos.DoktorDto
{
    public class UpdateDoktorDto
    {
        public int DoktorID { get; set; }
        public string DoktorName { get; set; }
        public string DoktorTelefon { get; set; }
        public string DoktorMail { get; set; }
        public DateTime GirisTarih { get; set; }
        public DateTime CikisTarih { get; set; }

    }
}
