namespace BolaoDaCopa2026.ViewModels
{
    public class AdminUsuarioVM
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int TotalApostas { get; set; }
    }
}
