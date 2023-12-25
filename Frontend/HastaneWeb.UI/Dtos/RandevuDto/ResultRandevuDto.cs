using HastaneWeb.EntityLayer.Concrete;

namespace HastaneWeb.UI.Dtos.RandevuDto
{
    public class ResultRandevuDto
    {
        public int RandevuID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string TelNo { get; set; }


        public int DoktorID { get; set; }
        public Doktor Doktor { get; set; }
        public string Sikayet { get; set; }

    }
}
