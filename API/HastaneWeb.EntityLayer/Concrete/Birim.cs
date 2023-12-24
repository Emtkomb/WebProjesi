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

        public int BirimID { get; set; }
        public string BirimAdi { get; set; }

        public List<Doktor> Doktorlar { get; set;}



    }
}
