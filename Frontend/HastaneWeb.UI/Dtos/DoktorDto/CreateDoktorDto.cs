using HastaneWeb.EntityLayer.Concrete;

namespace HastaneWeb.UI.Dtos.DoktorDto
{
    public class CreateDoktorDto
    {

        public string DoktorName { get; set; }

        public string DoktorTelefon { get; set; }
        public string DoktorMail { get; set; }
        public DateTime GirisTarih { get; set; }
        public DateTime CikisTarih { get; set; }
        public string Birimi { get; set; }



    }
}
