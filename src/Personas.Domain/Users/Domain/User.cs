using System;
using System.Collections;
using System.Collections.Generic;

namespace Personas.Domain
{
    public class User
    {
        public Guid Id { get; }
        private readonly UserName username;
        public IEnumerable<string> Roles { get; }

        public User(string id, string email, params string[] roles)
        {
            Id = Guid.Parse(id);
            username = new UserName(email);
            Roles = roles;
        }

        public override string ToString() => username.ToString();
    }
}
