using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.EntityLayer.Concrete
{
    public class Birim
    {
        [Key]

        public int BirimID { get; set; }
        public string? Name { get; set; }
        public int? HastaneID { get; set; }
        public Hastane? Hastane { get; set; }

        public  List<Doktor>? Doktorlar { get; set; } = new List<Doktor>();



    }
}
