using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class Persona
    {
        public string Dni { get; }
        public Nombre Nombre { get; }
        public Apellido PrimerApellido { get; }
        public Apellido SegundoApellido { get; }

        public Genero Genero { get; }
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
        
        public Persona(Nombre nombre, Apellido primerApellido, Apellido segundoApellido, 
            Genero genero, Lugar origen, DateTime fechaNacimiento, RandomProvider randomProvider)
        {
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Genero = genero;
            Origen = origen;
            FechaNacimiento = fechaNacimiento;
            Dni = new Dni(randomProvider).ToString();
            Cultura = Cultura.Spanish;
        }

        public string Detalle() => $"{Nombre}, {Edad()} años, de {Origen.ToString()}";
        public override string ToString() 
            => $"{Nombre.ToString()} {PrimerApellido.ToString()} {SegundoApellido.ToString()}";
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentNullException("El parametro debe ser un objeto de tipo persona");
            return (Dni == ((Persona)obj).Dni);
        }
        public override int GetHashCode() => Dni.GetHashCode();
    }
}
