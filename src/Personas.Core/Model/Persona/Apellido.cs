using System;

namespace Personas.Core
{ 
    public class Apellido
    {
        private readonly string apellido;
        public Idioma Idioma { get; }
        public FrecuenciaAparicion Frecuencia { get; }

        public Apellido(string apellido, FrecuenciaAparicion frecuencia, Idioma idioma)
        {
            if (apellido.IsEmpty())
                throw new ArgumentNullException(nameof(apellido));

            this.apellido = apellido;
            Frecuencia = frecuencia;
            Idioma = idioma;
        }

        public override string ToString() => apellido.Trim();
    }
}
