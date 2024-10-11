using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apirestful.DTOs
{
    public class ProductDTO
    {
        [Required]
        [MaxLength(100)]

        public string Name { get; set; }

        [MaxLength(150)]
        public string? Description { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        public int IdCategory { get; set; }
    }
}