namespace netfwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Provincias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Provincias()
        {
            Localidades = new HashSet<Localidades>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreProvincia { get; set; }

        public int IdRegion { get; set; }

        [StringLength(100)]
        public string GentilicioM { get; set; }

        [StringLength(100)]
        public string GentilicioF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Localidades> Localidades { get; set; }

        public virtual Regiones Regiones { get; set; }
    }
}
