using System;

namespace Personas.Shared
{
    public class PersonViewModel
    {
        public string IdNumber { get; set; }
        public NameViewModel FirstName { get; set; }
        public SurnameViewModel MiddleName { get; set; }
        public SurnameViewModel LastName { get; set; }
        public string CompleteName { get; set; }
        public string Gender { get; set; }
        public PlaceViewModel Place { get; set; }
        public string Culture { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string Detail { get; set; }
    }
}
