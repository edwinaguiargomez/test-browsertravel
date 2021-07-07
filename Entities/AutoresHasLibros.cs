using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// AutoresHasLibros object for mapped table autores_has_libros.
    /// </summary>
    [Table("autores_has_libros")]
    public partial class AutoresHasLibros : EntityInfrastructure
    {
        [Display(Name = "Autor")]
        [Required(ErrorMessage = "El campo Autor es obligatorio.")]
        [Column("autores_id")]
        public Int32 AutorId { get; set; }

        [ForeignKey("AutorId")]
        public virtual Autor Autor { get; set; }

        [Display(Name = "Libro")]
        [Required(ErrorMessage = "El campo Libro es obligatorio.")]
        [Column("libros_Id")]
        public Int32 LibrosId { get; set; }

        [ForeignKey("LibrosId")]
        public virtual Libro Libro { get; set; }

    }
}
