using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Personas.Data.Enums
{
    public enum TipoLocalidad
    {
        [Display(Name = "Metrópoli")]
        Metropoli = 1,

        [Display(Name = "Ciudad grande")]
        CiudadGrande = 2,

        [Display(Name = "Capital de provincias")]
        CapitalProvincias = 3,

        [Display(Name = "Pueblo grande")]
        PuebloGrande = 4,

        [Display(Name = "Pueblo pequeño")]
        PuebloPequenio = 5,
    }
}
