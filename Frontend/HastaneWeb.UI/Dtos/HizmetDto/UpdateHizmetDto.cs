using System.ComponentModel.DataAnnotations;

namespace HastaneWeb.UI.Dtos.HizmetDto
{
    public class UpdateHizmetDto
    {
        public int HizmetID { get; set; }

        [Required(ErrorMessage = "Hizmet ikonu giriniz.")]
        public string HizmetIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı giriniz")]
        [StringLength(50, ErrorMessage = "Hizmet başlığı en fazla 50 karakter olabilir.")]
        public string HizmetTitle { get; set; }

        [Required(ErrorMessage = "Hizmet açıklama giriniz")]
        public string HizmetAciklama { get; set; }
    }
}
