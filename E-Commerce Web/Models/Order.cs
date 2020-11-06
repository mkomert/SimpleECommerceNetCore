using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETic.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public int Id { get; set; }
        [Display(Name = "Sipariş Numarası")]
        public string OrderNo { get; set; }
        
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "İsim Alanı Eksik!"), MinLength(2, ErrorMessage = "Tek Harf İçeren İsim Girilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Telefon Numarası Eksik!"), MinLength(10, ErrorMessage = "Lütfen 11 Haneli Bir Numara Girin!"),MaxLength(12)]
        [Display(Name="Telefon Numarası")]
        
        public string PhoneNo { get; set; }
        
        
        [Required(ErrorMessage = "Mail Bilgisi Eksik!"), MinLength(2, ErrorMessage = "Tek Harf İçeren Mail Adresi Girilemez")]
        [Display(Name = "Mail Adresi")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Adres Bilgisi Eksik!"), MinLength(10, ErrorMessage = "Adresinizi tam olarak girin!")]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Tarih")]
        [Required(ErrorMessage = "Tarih Seçin!")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
