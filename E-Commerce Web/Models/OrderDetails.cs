using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ETic.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [Display(Name="Sipariş")]
        public int OrderId { get; set; }
        [Display(Name = "Ürün")]
        public int ProductId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("ProductId")]
        public Products Products { get; set; }
    }
}
