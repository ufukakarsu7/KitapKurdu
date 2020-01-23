using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Toplam")]
        public decimal TotalPrice { get; set; }
        [Required]
        [Display(Name = "Fatura No")]
        public int InvoiceNo { get; set; }
        [Required]
        [Display(Name = "Düzenlenme Tarihi")]
        public DateTime DateOfEdit { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}