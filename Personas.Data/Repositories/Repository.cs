using Util.Core.Data;

namespace Personas.Data.Repositories
{
    public class Repository
    {
        protected Conexion c;

        public Repository(Conexion conexion)
        {
            c = conexion;
        }
    }
}
