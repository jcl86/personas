using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class Lugar : Entity
    {
        public string Municipio { get; }
        public string Provincia { get; }
        public Region Region { get; }
        public string Pais { get; }

        private readonly TipoLocalidad tipo;
        private readonly string gentilicioMasculino;
        private readonly string gentilicioFemenino;

        public Lugar(int id, string municipio, string provincia, Region region, string pais, TipoLocalidad tipo, 
            string gentilicioMasculino, string gentilicioFemenino) : base(id)
        {
            Municipio = municipio;
            Provincia = provincia;
            Region = region;
            Pais = pais;
            this.tipo = tipo;
            this.gentilicioMasculino = gentilicioMasculino;
            this.gentilicioFemenino = gentilicioFemenino;
        }

        public string Tipo() => tipo.Descripcion();
        public string Gentilicio(Genero genero) => genero.IsMale ? gentilicioMasculino : gentilicioFemenino;

        public override string ToString() => $"{Municipio}, {Region.ToString()}";
        public string ToStringCompleto()
        {
            if (string.IsNullOrWhiteSpace(Provincia))
                return $"{Municipio}, {Region} ({Pais})";
            return $"{Municipio}, {Provincia} ({Region})";
        }
    }
}
