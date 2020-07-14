using System.ComponentModel.DataAnnotations;

namespace Personas.Shared
{
    public class UpdateModel
    {
        [Required]
        public string NewPassword { get; set; }
    }
}
