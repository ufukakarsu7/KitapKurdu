using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Shipper")]
    public class Shipper
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Firma Adı")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}