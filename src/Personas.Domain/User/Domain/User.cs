using System;

namespace Personas.Domain
{
    public class User
    {
        public Guid Id { get; }
        private readonly string username;

        public User(string id, string username)
        {
            Id = Guid.Parse(id);
            this.username = username;
        }

        public override string ToString() => username;
    }
}
