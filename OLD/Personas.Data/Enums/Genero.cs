using System.ComponentModel.DataAnnotations;

namespace Personas.Data.Enums
{
    public enum Genero
    {
        [Display(Name = "Hombre")]
        Male = 0,

        [Display(Name = "Mujer")]
        Female = 1
    }
}
