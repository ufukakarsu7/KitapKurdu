using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int ID { get; set; }
        
        [Display(Name = "Sipariş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        
        [Display(Name = "Teslimat Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? DateOfDelivery { get; set; }
       
        [Display(Name = "Gönderim Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? DateOfShipping { get; set; }

        [Display(Name = "Sipariş Onay")]
        public bool IsConfirmed { get; set; }
        
        [Display(Name = "Kargo Numarası")]
        public string CargoNumber { get; set; }

        [Display(Name = "Sipariş Saati")]
        [DataType(DataType.Time)]
        public TimeSpan? OrderTime { get; set; }

        public int? InvoiceID { get; set; }
       

        [ForeignKey("Shipper")]
        public int ShipperID { get; set; }
        public virtual Shipper Shipper { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }




    }
}