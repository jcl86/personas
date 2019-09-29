using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Personas.Data.Enums
{
    public enum TipoLocalidad
    {
        [Display(Name = "Metrópoli")]
        Metropoli = 1,

        [Display(Name = "Ciudad grande")]
        BigCity = 2,

        [Display(Name = "Capital de provincias")]
        BigTown = 3,

        [Display(Name = "Pueblo grande")]
        Town = 4,

        [Display(Name = "Pueblo pequeño")]
        Village = 5,
    }
}
