using System.ComponentModel.DataAnnotations;

namespace login_system.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "E-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Password { get; set; }
    }
}
