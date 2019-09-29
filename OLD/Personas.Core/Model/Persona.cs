using Personas.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Core.Model
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sobrenombre { get; set; }
        public string NombreCompleto => (Nombre.Trim() + " " + (PrimerApellido?.Trim() ?? "") + " " + (SegundoApellido?.Trim() ?? "")).Trim();

        public Genero Sexo { get; set; }
        public Lugar Origen { get; set; }
 
        public DateTime FechaNacimiento { get; set; }
        public int Edad => FechaNacimiento.CalcularEdad();
        public string FechaNacimientoCorta => FechaNacimiento.FechaCorta();
        public string FechaNacimientoLarga => FechaNacimiento.FechaLarga();
        
        public Persona(int id, string nombre, string apellido1, string apellido2, Genero genero, Lugar lugarOrigen, DateTime fNac)
        {
            Id = id;
            Nombre = nombre;
            PrimerApellido = apellido1;
            SegundoApellido = apellido2;
            Sexo = genero;
            Origen = lugarOrigen;
            FechaNacimiento = fNac;

            Sobrenombre = CalcularSobrenombre();
        }

        private string CalcularSobrenombre()
        {
            if (Nombre.Split(' ').Length >= 2)
            {
                if (Nombre.Length > 0)
                    return Nombre.Split(' ')[0].Substring(0, 1) + ". " + Nombre.Split(' ')[1] + " " + PrimerApellido;
                else
                    return string.Empty;
            }
            else
            {
                if ((PrimerApellido).Length > 8 || (Nombre + PrimerApellido).Length > 13)
                {
                    if (Nombre.Length > 0)
                        return Nombre.Substring(0, 1) + ". " + PrimerApellido;
                    else
                        return string.Empty;
                }
                else
                    return Nombre + " " + PrimerApellido;
            }
        }

        public bool EsTocayo(Persona p) =>(p.Nombre.Equals(Nombre));
        public bool MismosNombresApellidos(Persona p) => (p.NombreCompleto.Equals(NombreCompleto));
        public string Detalle() => $"{Sobrenombre}, {Edad} años, de {Origen.ToString()}";
        public override string ToString() => Sobrenombre;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentNullException("El parametro debe ser un objeto de tipo persona");
            return (Id == ((Persona)obj).Id);
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
