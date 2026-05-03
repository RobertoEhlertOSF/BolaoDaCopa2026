using System.ComponentModel.DataAnnotations;

namespace BolaoDaCopa2026.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Informe o email.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;
    }
}