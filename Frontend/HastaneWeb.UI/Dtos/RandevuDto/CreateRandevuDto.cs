

namespace HastaneWeb.UI.Dtos.RandevuDto
{
    public class CreateRandevuDto
    {

        public int RandevuID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string TelNo { get; set; }
        public DateTime RandevuGiris { get; set; }
        public DateTime RandevuCikis { get; set; }

        public string Birim { get; set; }
        public int DoktorID { get; set; }
        public string Sikayet { get; set; }
        public string Status { get; set; }

    }
}
