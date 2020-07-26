using System.ComponentModel.DataAnnotations;

namespace Personas.Shared
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
