namespace netfwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nombres
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int IdCultura { get; set; }

        public int Comun { get; set; }

        public bool NombreCompuesto { get; set; }

        public int Sexo { get; set; }

        public int IdIdioma { get; set; }

        public virtual Culturas Culturas { get; set; }

        public virtual Idiomas Idiomas { get; set; }
    }
}