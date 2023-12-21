using System.ComponentModel.DataAnnotations;

namespace HastaneWeb.UI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="İsim alanını giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soy isim alanını giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Şehir alanını giriniz.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı alanını giriniz.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Telefon numarası  giriniz.")]
        public string TelNo { get; set; }
        [Required(ErrorMessage = "Şifre giriniz.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifreyi tekrar giriniz.")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }


    }
}
