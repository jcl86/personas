namespace netfwk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lugares
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string NombreLocalidad { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TipoLocalidad { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProvincia { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string NombreProvincia { get; set; }

        [StringLength(100)]
        public string GentilicioMP { get; set; }

        [StringLength(100)]
        public string GentilicioFP { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRegion { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(100)]
        public string NombreRegion { get; set; }

        public int? Habitantes { get; set; }

        public int? Densidad { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdIdiomaOficial { get; set; }

        public int? IdIdiomaCooficial { get; set; }

        public int? PorcentajeIdiomaOficial { get; set; }

        [StringLength(100)]
        public string GentilicioMR { get; set; }

        [StringLength(100)]
        public string GentilicioFR { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPais { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string NombrePais { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string Idioma1 { get; set; }

        [StringLength(50)]
        public string Idioma2 { get; set; }
    }
}
