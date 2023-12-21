using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneWeb.DtoLayer.Dtos.DoktorDto
{
    public class AddDoktorDto
    {
        [Required(ErrorMessage ="Lütfen Doktor Adını Giriniz")]
        public string DoktorName { get; set; }

        [Required(ErrorMessage = "Lütfen Doktor Birimini Giriniz")]
        public string DoktorBirim { get; set; }

        [Required(ErrorMessage = "Lütfen Doktor Telefonunu Giriniz")]
        public string DoktorTelefon { get; set; }

        [Required(ErrorMessage = "Lütfen Doktor Mailini Giriniz")]
        public string DoktorMail { get; set; }
    }
}
