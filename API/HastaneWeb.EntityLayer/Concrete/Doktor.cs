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

        public int DoktorID { get; set; }
        public string DoktorName { get; set; }

        public string DoktorTelefon { get; set; }
        public string DoktorMail { get; set; }
        public DateTime GirisTarih { get; set; }
        public DateTime CikisTarih { get; set; }

        //public int BirimID  { get; set; }
        //public Birim Birim { get; set; }





    }
}

