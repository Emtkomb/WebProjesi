using HastaneWeb.EntityLayer.Concrete;

namespace HastaneWeb.UI.Dtos.RandevuDto
{
    public class CreateRandevuDto
    {

        public int RandevuID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string TelNo { get; set; }
        public int DoktorID { get; set; }

        public Doktor Doktor { get; set; }
        public DateTime RandevuGiris { get; set; }
        public DateTime RandevuCikis { get; set; }
        public string  Status { get; set; }
    }
}
