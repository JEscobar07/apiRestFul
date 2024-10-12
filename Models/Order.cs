using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Models;

namespace apiRestFul.Models
{
    [Table("orders")]
    public class Order
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id {get; set;}

        [Column("date")]
        [Required]
        [MaxLength(100)]

        public DateTime Date {get; set;}

        [Column("idCustomer")]
        public int? IdCustomer {get; set;}

        [ForeignKey("IdCustomer")]
        public Customer Customer {get; set;}
    }
}