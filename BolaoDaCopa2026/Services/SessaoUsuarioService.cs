using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BolaoDaCopa2026.Services
{
    public static class SessaoUsuarioService
    {
        public const string ClaimUsuarioId = "usuario_id";
        public const string ClaimApostadorId = "apostador_id";
        public const string ClaimNomeUsuario = "nome_usuario";
        public const string ClaimIsAdmin = "is_admin";

        public static void PreencherSessao(
            ISession session,
            int apostadorId,
            string nomeUsuario,
            int usuarioId,
            bool isAdmin)
        {
            session.SetInt32("ApostadorId", apostadorId);
            session.SetString("NomeUsuario", nomeUsuario);
            session.SetInt32("UsuarioId", usuarioId);
            session.SetString("IsAdmin", isAdmin ? "true" : "false");
        }

        public static void RestaurarSessaoSeAutenticado(HttpContext httpContext)
        {
            if (httpContext.User.Identity?.IsAuthenticated != true)
                return;

            var session = httpContext.Session;

            var usuarioIdAtual = session.GetInt32("UsuarioId");
            var apostadorIdAtual = session.GetInt32("ApostadorId");
            var nomeUsuarioAtual = session.GetString("NomeUsuario");

            if (usuarioIdAtual.HasValue &&
                apostadorIdAtual.HasValue &&
                !string.IsNullOrWhiteSpace(nomeUsuarioAtual))
            {
                return;
            }

            var usuarioIdClaim = httpContext.User.FindFirstValue(ClaimUsuarioId);
            var apostadorIdClaim = httpContext.User.FindFirstValue(ClaimApostadorId);
            var nomeUsuarioClaim = httpContext.User.FindFirstValue(ClaimNomeUsuario);
            var isAdminClaim = httpContext.User.FindFirstValue(ClaimIsAdmin);

            if (!int.TryParse(usuarioIdClaim, out var usuarioId) ||
                !int.TryParse(apostadorIdClaim, out var apostadorId) ||
                string.IsNullOrWhiteSpace(nomeUsuarioClaim))
            {
                return;
            }

            PreencherSessao(
                session,
                apostadorId,
                nomeUsuarioClaim,
                usuarioId,
                string.Equals(isAdminClaim, "true", StringComparison.OrdinalIgnoreCase));
        }
    }
}
