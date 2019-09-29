namespace netfwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Localidades
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int IdProvincia { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreLocalidad { get; set; }

        public int TipoLocalidad { get; set; }

        public virtual Provincias Provincias { get; set; }
    }
}
