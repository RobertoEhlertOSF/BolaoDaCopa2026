using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.Services
{
    public class ApostaPrazoService
    {
        private const string StatusFinalizado = "Finalizado";
        private const string StatusEmAndamentoSemEspaco = "EmAndamento";
        private const string StatusEmAndamentoComEspaco = "Em andamento";

        public DateTime ObterAgora() => DateTime.Now;

        public bool PodeApostar(Jogo jogo, DateTime? agora = null)
        {
            ArgumentNullException.ThrowIfNull(jogo);

            if (StatusIndicaJogoFechado(jogo))
                return false;

            var referencia = agora ?? ObterAgora();
            return jogo.DataHora > referencia;
        }

        public string ObterStatusCronologico(Jogo jogo, DateTime? agora = null)
        {
            ArgumentNullException.ThrowIfNull(jogo);

            if (StatusEh(jogo.Status, StatusFinalizado))
                return StatusFinalizado;

            return PodeApostar(jogo, agora) ? "Agendado" : "Em andamento";
        }

        private static bool StatusIndicaJogoFechado(Jogo jogo) =>
            StatusEh(jogo.Status, StatusFinalizado)
            || StatusEh(jogo.Status, StatusEmAndamentoSemEspaco)
            || StatusEh(jogo.Status, StatusEmAndamentoComEspaco);

        private static bool StatusEh(string? statusAtual, string statusEsperado) =>
            string.Equals(statusAtual?.Trim(), statusEsperado, StringComparison.OrdinalIgnoreCase);
    }
}
