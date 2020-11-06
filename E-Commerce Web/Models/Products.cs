using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ETic.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }
        [Display(Name="Fiyat")]
        
        public decimal Price { get; set; }
        [Display(Name = "Ürün Görseli")]
        public string Image { get; set; }
        [Display(Name = "Ürün Rengi")]
        public string productColor { get; set; }
        [Display(Name = "Stok Durumu")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Kategori")]
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductTypes ProductTypes { get; set; }
        [Display(Name = "Etiket")]
        public int SpecialTagId { get; set; }
        [ForeignKey("SpecialTagId")]
        public SpecialTags SpecialTags { get; set; }

    }
}
