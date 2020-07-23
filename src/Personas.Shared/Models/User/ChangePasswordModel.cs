using System.ComponentModel.DataAnnotations;

namespace Personas.Shared
{
    public class ChangePasswordModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
