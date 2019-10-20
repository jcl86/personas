using System.ComponentModel;

namespace Personas.Core
{
    public enum FrecuenciaAparicion
    {
        [Description("Muy común")]
        MuyComun,

        [Description("Frecuente")]
        Frecuente,

        [Description("Normal")]
        Normal,

        [Description("No tan común")]
        NoTanComun,

        [Description("Raro")]
        Raro,

        [Description("Muy raro")]
        MuyRaro
    }
}
