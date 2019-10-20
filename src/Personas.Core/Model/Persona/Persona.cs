using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Core
{
    public class Nombre
    {
        private readonly string nombre;

        public Nombre(string nombre)
        {
            this.nombre = nombre;
        }
    }
    public class Persona
    {
        public string Dni { get; }
        public string Nombre { get; }
        public string PrimerApellido { get; }
        public string SegundoApellido { get; }

        public Genero Sexo { get; }
        public Lugar Origen { get; }
        public Cultura Cultura { get; }

        public DateTime FechaNacimiento { get; }
        public int Edad()
        {
            var age = DateTime.Now.Year - FechaNacimiento.Year;
            if (DateTime.Now < FechaNacimiento.AddYears(age))
                age--;
            return age;
        }
        
        public Persona(string nombre, string apellido1, string apellido2, Genero genero, Lugar origen, DateTime fechaNacimiento, IRandomProvider randomProvider)
        {
            Nombre = nombre;
            PrimerApellido = apellido1;
            SegundoApellido = apellido2;
            Sexo = genero;
            Origen = origen;
            FechaNacimiento = fechaNacimiento;
            Dni = new Dni(randomProvider).ToString();
            Cultura = Cultura.Spanish;
        }

        public string Detalle() => $"{Nombre}, {Edad()} años, de {Origen.ToString()}";
        public override string ToString() => $"{Nombre.Trim()} {PrimerApellido.Trim()} {SegundoApellido}";
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentNullException("El parametro debe ser un objeto de tipo persona");
            return (Dni == ((Persona)obj).Dni);
        }
        public override int GetHashCode() => Dni.GetHashCode();
    }
}
