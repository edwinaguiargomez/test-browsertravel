using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Autor object for mapped table autores.
    /// </summary>
    [Table("autores")]
    public partial class Autor : EntityInfrastructure
    {
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        [MaxLength(45, ErrorMessage = "El campo Nombres debe tener como máximo 45 caracteres.")]
        [Column("nombres")]
        public String Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo Apellidos es obligatorio.")]
        [MaxLength(45, ErrorMessage = "El campo Apellidos debe tener como máximo 45 caracteres.")]
        [Column("apellidos")]
        public String Apellidos { get; set; }

    }
}
