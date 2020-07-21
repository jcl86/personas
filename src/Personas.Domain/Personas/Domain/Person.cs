using Personas.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class Person
    {
        public string IdCardNumber { get; }
        public Name FirstName { get; }
        public Surname MiddleName { get; }
        public Surname LastName { get; }

        public Gender Gender { get; }
        public Place Place { get; }
        public Culture Culture { get; }

        public DateTime BirthDate { get; }
        public int Age()
        {
            var age = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now < BirthDate.AddYears(age))
                age--;
            return age;
        }
        
        public Person(Name firstName, Surname middleName, Surname lastname, 
            Gender gender, Place place, DateTime birthday, string idCardNumber)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastname;
            Gender = gender;
            Place = place;
            BirthDate = birthday;
            IdCardNumber = idCardNumber;
            Culture = Culture.Spanish;
        }

        public string Detail() => $"{FirstName}, {Age()} años, de {Place}";
        public override string ToString()  => $"{FirstName} {MiddleName} {LastName}";
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                throw new ArgumentNullException("El parametro debe ser un objeto de tipo persona");
            return IdCardNumber == ((Person)obj).IdCardNumber;
        }
        public override int GetHashCode() => IdCardNumber.GetHashCode();
    }
}
