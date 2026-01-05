using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CodeFirst.Models
{
    public class Sales
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime? SaleDate { get; set; }
        public int QtySold { get; set; }
        public double SaleTotal { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}