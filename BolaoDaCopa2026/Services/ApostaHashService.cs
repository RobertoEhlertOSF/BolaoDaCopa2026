using System.Security.Cryptography;
using System.Text;

namespace BolaoDaCopa2026.Services
{
    public static class ApostaHashService
    {
        public static string GerarSalt()
        {
            var bytes = RandomNumberGenerator.GetBytes(32);
            return Convert.ToBase64String(bytes);
        }

        public static string GerarPayload(int jogoId, int apostadorId, int golsA, int golsB)
        {
            // FORMATO FIXO — nunca mudar sem versionar
            return $"type=APOSTA|jogoId={jogoId}|apostadorId={apostadorId}|A={golsA}|B={golsB}|v=1";
        }

        public static string GerarHash(string payload, string salt)
        {
            var raw = $"{payload}|{salt}";
            var bytes = Encoding.UTF8.GetBytes(raw);
            var hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool Validar(string payload, string salt, string hash)
        {
            var novoHash = GerarHash(payload, salt);
            return novoHash == hash;
        }
    }
}
