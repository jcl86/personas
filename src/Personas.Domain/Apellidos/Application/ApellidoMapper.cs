using Personas.Shared;

namespace Personas.Domain
{
    public class ApellidoMapper
    {
        private readonly Apellido apellido;

        public ApellidoMapper(Apellido apellido)
        {
            this.apellido = apellido;
        }

        public ApellidoViewModel Map()
        {
            return new ApellidoViewModel()
            {
                Apellido = apellido.ToString(),
                Idioma = apellido.Idioma.ToString(),
                Frecuencia = apellido.Frecuencia.Descripcion()
            };
        }
    }
}
