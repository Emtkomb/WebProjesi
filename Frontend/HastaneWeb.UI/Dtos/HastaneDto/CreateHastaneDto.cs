using HastaneWeb.EntityLayer.Concrete;

namespace HastaneWeb.UI.Dtos.HastaneDto
{
    public class CreateHastaneDto
    {

        public string HastaneAdi { get; set; }
        public string HastaneAdresi { get; set; }
        public string HastaneTelefon { get; set; }
        public string HastaneResim { get; set; }
        public List<Doktor> Doktorlar { get; set; }
    }
}
