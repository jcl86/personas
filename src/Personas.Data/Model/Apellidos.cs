using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class Apellidos
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        public int IdCultura { get; set; }

        public int Comun { get; set; }

        public bool ApellidoCompuesto { get; set; }

        public int IdIdioma { get; set; }

        public virtual Culturas Culturas { get; set; }

        public virtual Idiomas Idiomas { get; set; }
    }

    public class ApellidoConfiguration : IEntityConfiguration
}
