using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CodeFirst.Models
{
    [Table("ProductsTable")]
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price {  get; set; }
        public int Quantity {  get; set; }
    }
}