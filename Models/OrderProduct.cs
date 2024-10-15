using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Models;

namespace apiRestFul.Models
{
    [Table("order_products")]
    public class OrderProduct
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [Column("idProduct")]
        public int IdProduct{get; set;}

        [Column("idOrder")]
        public int IdOrder{get; set;}

        [ForeignKey("IdProduct")]
        public Product Product {get; set;}

        [ForeignKey("IdOrder")]
        public Order Order {get; set;}
    }
}