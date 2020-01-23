using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name ="Başlık")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "İlçe")]
        public string District { get; set; }
        [Required]
        [Display(Name = "İl")]
        public string City { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }


    }
}