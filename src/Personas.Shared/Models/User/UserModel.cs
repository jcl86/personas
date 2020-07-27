using System;
using System.Collections;
using System.Collections.Generic;

namespace Personas.Shared
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
