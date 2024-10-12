using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apirestful.Models
{
    [Table("customers")]
    public class Customer
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [Column("name")]
        [MaxLength(100)]
        public string Name {get; set;}

        [Column("address")]
        [MaxLength(255)]
        public string? Address {get; set;}

        [Column("number_contact")]
        [MaxLength(100)]
        public string? NumberContact {get; set;}

    }
}