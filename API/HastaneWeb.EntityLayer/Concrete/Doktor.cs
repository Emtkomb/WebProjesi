using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.EntityLayer.Concrete
{
    public class Doktor
    {
        [Key]
        public int DoktorID { get; set; }
        public string? DoktorName { get; set; }

        public string? DoktorTelefon { get; set; }
        public string? DoktorMail { get; set; }

        public string? DoktorResim { get; set; } 
        public DateTime? GirisTarih { get; set; }
        public DateTime? CikisTarih { get; set; }

        public int? BirimID { get; set; }

        public Birim? Birim { get; set; }
        public int? HastaneID { get; set; }

        public Hastane? Hastane { get; set; }
        public List<Randevu>? Randevular { get; set; } = new List<Randevu>();




    }
}

