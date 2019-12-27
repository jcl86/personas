using Microsoft.Extensions.Logging;

namespace Personas.Api
{
    public sealed class PersonasLog
    {
        public static EventId PersonasId = new EventId(1, nameof(PersonasId));
        public static EventId LugaresId = new EventId(2, nameof(LugaresId));
        public static EventId NombresId = new EventId(3, nameof(NombresId));
        public static EventId ApellidosId = new EventId(4, nameof(ApellidosId));
    }
}
