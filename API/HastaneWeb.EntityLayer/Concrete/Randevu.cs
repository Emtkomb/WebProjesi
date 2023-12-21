using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.EntityLayer.Concrete
{
    public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string TelNo { get; set; }
        public DateTime RandevuGiris { get; set; }
        public DateTime RandevuCikis { get; set; }
        public string Status { get; set; }
        public int DoktorID { get; set; }
        public Doktor Doktor { get; set; }

    }
}
