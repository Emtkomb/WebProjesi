using System.ComponentModel.DataAnnotations;

namespace HastaneWeb.UI.Dtos.BirimDto
{
    public class CreateBirimDto
    {
        [Required(ErrorMessage = "Birim Adı giriniz.")]
        public string Name { get; set; }
    }
}
