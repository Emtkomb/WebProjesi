using HastaneWeb.EntityLayer.Concrete;

namespace HastaneWeb.UI.Models.Doktor
{
    public class AddDoktorViewModel
    {
        public int DoktorID { get; set; }
        public string DoktorName { get; set; }
        public int HastaneID { get; set; }

        public int BirimID { get; set; }
        public Birim Birim { get; set; }



        public string DoktorTelefon { get; set; }
        public string DoktorMail { get; set; }
        public DateTime GirisTarih { get; set; }
        public DateTime CikisTarih { get; set; }
        public List<Randevu> Randevular { get; set; }
    }
}
