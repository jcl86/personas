using System;

namespace Personas.Domain
{
    public class User
    {
        public Guid Id { get; }
        private readonly string username;

        public User(Guid id, string username)
        {
            this.Id = id;
            this.username = username;
        }

        public override string ToString() => username;
    }
}
