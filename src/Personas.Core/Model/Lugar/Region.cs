using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Core
{
    public class Region : Entity
    {
        public string Nombre { get; private set; }
        public int Habitantes { get; private set; }
        public int Densidad { get; private set; }

        private readonly List<Idioma> idiomas;
        private readonly string gentilicioMasculino;
        private readonly string gentilicioFemenino;

        public Region(int id, string nombre, int habitantes, int densidad, string gentilicioMasculino, string gentilicioFemenino,
            Idioma idiomaOficial, Idioma idiomaCooficial = null) : base(id)
        {
            Nombre = nombre;
            Habitantes = habitantes;
            Densidad = densidad;

            idiomas = new List<Idioma>() { idiomaOficial };
            if (idiomaCooficial != null)
                idiomas.Add(idiomaCooficial);

            this.gentilicioMasculino = gentilicioMasculino;
            this.gentilicioFemenino = gentilicioFemenino;
        }

        public int Superficie => (Habitantes / Densidad / 100) * 100;        

        public Idioma LenguaOficial => idiomas.First();
        public Idioma LenguaCooficial => idiomas.Count > 1 ? idiomas[1] : null;
        public string Lenguas => string.Join(" y ", idiomas);
        public string Gentilicio(Genero genero) => genero.IsMale ? gentilicioMasculino : gentilicioFemenino;

        public override string ToString() => Nombre;
        
        public string TextoDescriptivo()
        {
            return $"{Nombre} es una comunidad autónoma en la que se habla {Lenguas}. " +
                $"Tiene alrededor de {Habitantes} habitantes, " +
                $"y una densidad de de población de {Densidad} hab/km2\n";
        }
    }
}
