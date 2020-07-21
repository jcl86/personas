using System.ComponentModel;

namespace Personas.Domain
{
    public enum CityType
    {
        [Description("Una auténtica metrópoli")]
        Metropoli = 1,

        [Description("Una gran ciudad")]
        BigCity = 2,

        [Description("Una ciudad")]
        BigTown = 3,

        [Description("Un pueblo grande")]
        Town = 4,

        [Description("Un pequeño pueblo")]
        Village = 5,
    }
}
