using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.DtoLayer.Dtos.HastaneDto
{
    public class AddHastaneDto
    {
        public int HastaneID { get; set; }
        public string HastaneAdi { get; set; }
        public string HastaneAdresi { get; set; }
        public string HastaneTelefon { get; set; }
        public string HastaneResim { get; set; }
    }
}
