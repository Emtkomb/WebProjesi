using System.ComponentModel.DataAnnotations;

namespace HastaneWeb.UI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı adı alanını giriniz.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre giriniz.")]
        public string Password { get; set; }
    }
       
}
