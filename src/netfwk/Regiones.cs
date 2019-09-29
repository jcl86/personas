namespace netfwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Regiones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Regiones()
        {
            Provincias = new HashSet<Provincias>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreRegion { get; set; }

        public int IdPais { get; set; }

        public int Habitantes { get; set; }

        public int Densidad { get; set; }

        public int IdIdiomaOficial { get; set; }

        public int? IdIdiomaCooficial { get; set; }

        public int? PorcentajeIdiomaOficial { get; set; }

        [StringLength(100)]
        public string GentilicioM { get; set; }

        [StringLength(100)]
        public string GentilicioF { get; set; }

        public virtual Idiomas Idiomas { get; set; }

        public virtual Idiomas Idiomas1 { get; set; }

        public virtual Paises Paises { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Provincias> Provincias { get; set; }
    }
}
