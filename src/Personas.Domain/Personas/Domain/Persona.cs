using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class Persona
    {
        public string Dni { get; }
        public Name Nombre { get; }
        public Surname PrimerApellido { get; }
        public Surname SegundoApellido { get; }

        public Gender Genero { get; }
        public Place Origen { get; }
        public Culture Cultura { get; }

        public DateTime FechaNacimiento { get; }
        public int Edad()
        {
            var age = DateTime.Now.Year - FechaNacimiento.Year;
            if (DateTime.Now < FechaNacimiento.AddYears(age))
                age--;
            return age;
        }
        
        public Persona(Name nombre, Surname primerApellido, Surname segundoApellido, 
            Gender genero, Place origen, DateTime fechaNacimiento, RandomProvider randomProvider)
        {
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Genero = genero;
            Origen = origen;
            FechaNacimiento = fechaNacimiento;
            Dni = new Dni(randomProvider).ToString();
            Cultura = Culture.Spanish;
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
