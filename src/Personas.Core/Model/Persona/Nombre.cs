using System;

namespace Personas.Core
{
    public class Nombre
    {
        private readonly string nombre;
        public bool EsCompuesto { get; }
        public FrecuenciaAparicion Frecuencia { get; }

        public Nombre(string nombre, bool esCompuesto, FrecuenciaAparicion frecuencia)
        {
            if (nombre.IsEmpty())
                throw new ArgumentNullException(nameof(nombre));

            this.nombre = nombre;
            EsCompuesto = esCompuesto;
            Frecuencia = frecuencia;
        }

        public override string ToString() => nombre.Trim();
    }
}
