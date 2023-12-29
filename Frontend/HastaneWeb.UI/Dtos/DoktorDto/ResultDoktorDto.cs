using HastaneWeb.EntityLayer.Concrete;

namespace HastaneWeb.UI.Dtos.DoktorDto
{
    public class ResultDoktorDto
    {
        public int DoktorID { get; set; }
        public string DoktorName { get; set; }
       public string DoktorTelefon { get; set; }
        public string DoktorMail { get; set; }
        public string DoktorResim { get; set; }
        public DateTime GirisTarih { get; set; }
        public DateTime CikisTarih { get; set; }

        public int BirimID { get; set; }
        public Birim Birim { get; set; } = new Birim();

    }
}
