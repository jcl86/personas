using System.ComponentModel.DataAnnotations;

namespace Personas.Data.Enums
{
    public enum Cultura
    {
        [Display(Name ="Española")]
        Spanish = 1,

        [Display(Name = "Inglesa")]
        English = 2,
    }
}
