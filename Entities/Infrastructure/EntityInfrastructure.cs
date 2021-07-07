using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Infrastructure
{
    public class EntityInfrastructure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        [Column("id")]
        public virtual Int32 Id { get; set; }
    }
}
