using Personas.Data.Enums;
using Personas.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Core.Model
{
    public class Region
    {
        public int IdRegion { get; private set; }
        public string Nombre { get; private set; }
        public int Habitantes { get; private set; }
        public int Densidad { get; private set; }
        public int? PorcentajeIdiomaOficial { get; private set; }

        private List<Idiomas> lenguas;
        private readonly string gentilicioM;
        private readonly string gentilicioF;

        public Region(Lugares l)
        {
            IdRegion = l.IdRegion;
            Nombre = l.NombreRegion;
            Habitantes = l.Habitantes ?? 0;
            Densidad = l.Densidad ?? 0;
            PorcentajeIdiomaOficial = l.PorcentajeIdiomaOficial;

            lenguas = new List<Idiomas> { new Idiomas() { Id = l.IdIdiomaOficial, NombreIdioma = l.Idioma1 } };
            if (l.PorcentajeIdiomaOficial.HasValue && l.IdIdiomaCooficial.HasValue) 
                lenguas.Add(new Idiomas() { Id = l.IdIdiomaCooficial.Value, NombreIdioma = l.Idioma2 });

            gentilicioM = l.GentilicioMR;
            gentilicioF = l.GentilicioFR;
        }

        /// <summary>
        /// Devuelve la superficie de la comunidad o región redondeada a las centenas
        /// </summary>
        /// <returns>numero entero</returns>
        public int Superficie => (Habitantes / Densidad / 100) * 100;

        /// <summary>
        /// Devuelve la superficie en formato texto
        /// </summary>
        /// <returns>Texto con separador de miles</returns>
        public string GetSuperficie => Superficie.ToFormatString();
        

        /// <summary>
        /// Devuelve los habitantes en modo texto
        /// </summary>
        /// <returns>texto con separador de miles</returns>
        public string GetHabitantes => Habitantes.ToFormatString();
        

        public bool MayorPoblacion(Region r)
        {
            if (r == null)
                throw new ArgumentNullException("Región nula");
            return (Habitantes > r.Habitantes);
        }

        public Idiomas LenguaOficial => lenguas.First();
        public Idiomas LenguaCooficial => lenguas.Count > 1 ? lenguas[1] : null;
        public string Lenguas => string.Join(" y ", lenguas);
        public string Gentilicio(Genero genero = Genero.Masculino) => genero.Equals(Genero.Masculino) ? gentilicioM : gentilicioF;
        public Idiomas LenguajeAleatorio()
        {
            if (PorcentajeIdiomaOficial == null || Lenguas.Length <= 1)
                return lenguas.First();
            return PorcentajeIdiomaOficial.Value.PorCiento() ? lenguas.First() : lenguas[1];
        }

        public override string ToString() => Nombre;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Region)obj).IdRegion == IdRegion;
        }
        public override int GetHashCode() => IdRegion.GetHashCode();
        
        public string TextoDescriptivo()
        {
            return $"{Nombre} es una comunidad autónoma. En ella se habla {Lenguas}. Tiene alrededor de { GetHabitantes}, " +
                $"y una densidad de de población de {Densidad} hab/km2\n" +
                $"Sus habitantes se hacen llamar {Gentilicio()}.";
        }
    }
}
