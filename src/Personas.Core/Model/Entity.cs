namespace Personas.Core
{
    public class Entity
    {
        public int Id { get; private set; }

        public Entity(int id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Entity)obj).Id == Id;
        }
        public override int GetHashCode() => Id.GetHashCode();
    }
}
