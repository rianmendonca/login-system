using login_system.Helper;
using System.ComponentModel.DataAnnotations;

namespace login_system.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s]+$", ErrorMessage = "Apenas letras, espaços e acentos são permitidos")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Nome deve conter entre 3 e 60 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [StringLength(int.MaxValue, MinimumLength = 8, ErrorMessage = "Senha deve conter pelo menos 8 caracteres")]
        public string Password { get; set; }

        public bool ValidatePassword(string password)
        {
            return Password.Equals(password.GenerateHash());
        }

        public void SetPasswordHash()
        {
            Password = Password.GenerateHash();
        }

        public void SetNewSenha(string newPassword)
        {
            Password = newPassword.GenerateHash();
        }

    }
}
