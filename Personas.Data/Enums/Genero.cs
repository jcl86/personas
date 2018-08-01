using System.ComponentModel.DataAnnotations;

namespace Personas.Data.Enums
{
    public enum Genero
    {
        [Display(Name = "Hombre")]
        Masculino = 0,

        [Display(Name = "Mujer")]
        Femenino = 1
    }
}
