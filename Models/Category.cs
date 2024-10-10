using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apirestful.Models
{
    [Table("categories")]
    public class Category
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [Column("name")]
        [Required]
        [MaxLength(100)]

        public string Name {get; set;}

        [Column("description")]
        [MaxLength(150)]
        public string? Description {get; set;}

    }
}