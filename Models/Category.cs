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
        public int id {get; set;}

        [Column("name")]
        [MaxLength(100)]
        [Required]
        public string Name {get; set;}

        [Column("description")]
        [MaxLength(150)]
        public string? Description {get; set;}

    }
}