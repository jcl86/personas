using System;

namespace Personas.Domain
{
    public class Role
    {
        public Guid Id { get; }
        private readonly string name;

        public Role(string id, string name)
        {
            Id = Guid.Parse(id);
            this.name = name;
        }

        public override string ToString() => name;
    }
}
