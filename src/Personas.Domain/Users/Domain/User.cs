using System;

namespace Personas.Domain
{
    public class User
    {
        public Guid Id { get; }
        private readonly UserName username;

        public User(string id, string email)
        {
            Id = Guid.Parse(id);
            username = new UserName(email);
        }

        public override string ToString() => username.ToString();
    }
}
