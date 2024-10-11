using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apirestful.Models
{
    [Table("products")]
    public class Product
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

        [Column("price")]
        public double Price {get; set;}
        
        [Column("stock")]
        public int Stock {get; set;}

        [Column("idCategory")]
        public int IdCategory {get; set;}

        [ForeignKey("IdCategory")]
        public Category Category {get; set;}

    }
}