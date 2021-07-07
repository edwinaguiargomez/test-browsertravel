using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// AutoresHasLibros object for mapped table autores_has_libros.
    /// </summary>
    [Table("editoriales")]
    public partial class Editorial : EntityInfrastructure
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(45, ErrorMessage = "El campo Nombre debe tener como máximo 45 caracteres.")]
        [Column("nombre")]
        public String Nombre { get; set; }

        [Display(Name = "Sede")]
        [Required(ErrorMessage = "El campo Sede es obligatorio.")]
        [MaxLength(45, ErrorMessage = "El campo Sede debe tener como máximo 45 caracteres.")]
        [Column("sede")]
        public String Sede { get; set; }

    }
}
