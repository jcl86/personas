using System;
using System.ComponentModel.DataAnnotations;

namespace Personas.Shared
{
    public class UserCreate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
