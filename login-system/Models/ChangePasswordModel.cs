using System.ComponentModel.DataAnnotations;

namespace login_system.Models
{
    public class ChangePasswordModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Senha atual é obrigatória")]
        public string CurrentPassword { get; set; }
        
        [Required(ErrorMessage = "Nova senha é obrigatória")]
        [Compare("ConfirmNewPassword", ErrorMessage = "Senhas não coincidem")]

        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirmação de nova senha é obrigatória")]
        [Compare("NewPassword", ErrorMessage = "Senhas não coincidem")]
        public string ConfirmNewPassword { get; set; }
    }
}
