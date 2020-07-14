using Personas.Shared;

namespace Personas.Domain
{
    public class NombreMapper
    {
        private readonly Nombre nombre;

        public NombreMapper(Nombre nombre)
        {
            this.nombre = nombre;
        }

        public NombreViewModel Map()
        {
            return new NombreViewModel()
            {
                Nombre = nombre.ToString(),
                EsCompuesto = nombre.EsCompuesto,
                Frecuencia = nombre.Frecuencia.Descripcion(),
                Genero = nombre.Genero.ToString()
            };
        }
    }
}
