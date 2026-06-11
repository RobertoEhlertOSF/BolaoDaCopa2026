namespace BolaoDaCopa2026.Services
{
    public class HorarioOficialService
    {
        private static readonly string[] TimeZoneIds =
        {
            "America/Sao_Paulo",
            "E. South America Standard Time"
        };

        private readonly TimeZoneInfo _timeZoneInfo;

        public HorarioOficialService()
        {
            _timeZoneInfo = ResolverTimeZone();
        }

        public DateTime ObterAgora()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZoneInfo);
        }

        public DateTime ConverterUtcParaHorarioOficial(DateTime dataHoraUtc)
        {
            var dataHoraEmUtc = dataHoraUtc.Kind == DateTimeKind.Utc
                ? dataHoraUtc
                : DateTime.SpecifyKind(dataHoraUtc, DateTimeKind.Utc);

            return TimeZoneInfo.ConvertTimeFromUtc(dataHoraEmUtc, _timeZoneInfo);
        }

        private static TimeZoneInfo ResolverTimeZone()
        {
            foreach (var timeZoneId in TimeZoneIds)
            {
                try
                {
                    return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                }
                catch (TimeZoneNotFoundException)
                {
                }
                catch (InvalidTimeZoneException)
                {
                }
            }

            throw new InvalidOperationException("Nao foi possivel localizar o fuso horario oficial do bolao.");
        }
    }
}
