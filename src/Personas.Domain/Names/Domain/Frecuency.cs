using System.ComponentModel;

namespace Personas.Domain
{
    public enum Frecuency
    {
        [Description("Muy común")]
        VeryCommon,

        [Description("Frecuente")]
        Common,

        [Description("Normal")]
        Regular,

        [Description("No tan común")]
        NotSoRegular,

        [Description("Raro")]
        Unusual,

        [Description("Muy raro")]
        Infrecuent
    }
}
