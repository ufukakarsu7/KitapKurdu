using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [Column(Order=0)]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

        [Key]
        [Column(Order = 1)]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }

        [Required]
        [Display(Name = "Fiyat")]
        public decimal UnitPrice { get; set; }
        [Required]
        [Display(Name = "Miktar")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "İndirim")]
        public float? Discount { get; set; }

    }
}