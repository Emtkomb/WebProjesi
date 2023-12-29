using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.EntityLayer.Concrete
{
    public class Hastane
    {
		[Key]
		public int? HastaneID { get; set; }
        public string? HastaneAdi { get; set; }
        public string? HastaneAdresi { get; set; }
        public string? HastaneTelefon { get; set; }
        public string? HastaneResim { get; set; }
        public List<Birim>? Birimler { get; set; } = new List<Birim>();
        public List<Doktor>? Doktorlar { get; set; } = new List<Doktor>();


    }
}
