using Personas.Data.Enums;
using Personas.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Core.Model
{
    [Serializable]
    public class Lugar
    {
        public int Id { get; private set; }
        public string Municipio { get; private set; }
        public string Provincia { get; private set; }
        public Region Comunidad { get; private set; }
        public string Pais { get; private set; }

        private TipoLocalidad Tipo;
        private readonly string gentilicioM;
        private readonly string gentilicioF;

        public Lugar(Lugares l)
        {
            Id = l.Id;
            Municipio = l.NombreLocalidad;
            Provincia = l.NombreProvincia;
            Comunidad = new Region(l);
            Pais = l.NombrePais;
            Tipo = (TipoLocalidad)l.TipoLocalidad;
            gentilicioM = l.GentilicioMP;
            gentilicioF = l.GentilicioFP;
        }

        public string TipoDeLocalidad() => Tipo.DisplayName();
        public string Gentilicio(Genero g = Genero.Masculino) => g.Equals(Genero.Masculino) ? gentilicioM : gentilicioF;

        public override string ToString() => $"{Municipio}, {Comunidad.ToString()}";
        public string ToStringCompleto()
        {
            if (String.IsNullOrWhiteSpace(Provincia))
                return Municipio + ", " + Comunidad + " (" + Pais + ")";
            return Municipio + ", " + Provincia + " (" + Comunidad + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ((Lugar)obj).Id == Id;
        }
        public override int GetHashCode() => Id.GetHashCode();
    }

}
