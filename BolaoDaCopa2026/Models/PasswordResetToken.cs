using System.ComponentModel.DataAnnotations;

namespace BolaoDaCopa2026.Models
{
    public class PasswordResetToken
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;

        [Required]
        public string TokenHash { get; set; } = string.Empty;

        public DateTime CriadoEmUtc { get; set; } = DateTime.UtcNow;

        public DateTime ExpiraEmUtc { get; set; }

        public bool Utilizado { get; set; }

        public DateTime? UtilizadoEmUtc { get; set; }
    }
}