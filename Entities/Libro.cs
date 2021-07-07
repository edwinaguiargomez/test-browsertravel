using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Libro object for mapped table libros.
    /// </summary>
    [Table("libros")]
    public partial class Libro : EntityInfrastructure
    {
        [Display(Name = "Título")]
        [Required(ErrorMessage = "El campo Titulo es obligatorio.")]
        [MaxLength(45, ErrorMessage = "El campo Titulo debe tener como máximo 45 caracteres.")]
        [Column("titulo")]
        public String Titulo { get; set; }

        [Display(Name = "Sinopsis")]
        [Required(ErrorMessage = "El campo Titulo es obligatorio.")]
        [MaxLength]
        [Column("sinopsis")]
        public String Sinopsis { get; set; }

        [Display(Name = "Número de paginas")]
        [Required(ErrorMessage = "El campo NPaginas es obligatorio.")]
        [MaxLength(45, ErrorMessage = "El campo NPaginas debe tener como máximo 45 caracteres.")]
        [Column("n_paginas")]
        public String NPaginas { get; set; }

        [Display(Name = "Editorial")]
        [Required(ErrorMessage = "El campo Editorial es obligatorio.")]
        [Column("editoriales_id")]
        public Int32 EditorialId { get; set; }

        [ForeignKey("EditorialId")]
        public Editorial Editorial { get; set; }

    }
}
