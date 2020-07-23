using Personas.Shared;

namespace Personas.Domain
{
    public class UserName
    {
        private readonly string email;

        public UserName(string email)
        {
            if (email.IsEmpty())
            {
                throw new DomainException("Email of username can not be empty");
            }

            if (!email.IsValidEmailAddress())
            {
                throw new DomainException($"{email} is not a valid email address");
            }

            this.email = email.Trim();
        }

        public override string ToString() => email;

        public override bool Equals(object obj)
        {
            if (obj is UserName other)
            {
                return other.email.Equals(email);
            }

            return false;
        }

        public override int GetHashCode() => email.GetHashCode();
    }
}
