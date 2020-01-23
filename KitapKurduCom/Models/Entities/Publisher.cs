using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Firma Ad")]
        [Column("Name")]
        public string PublisherName { get; set; }
        [Required]
        [Display(Name = "Firma Çalışanı")]
        public string ContactName { get; set; }
        [Required]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Tedarik Süresi")]
        public int SupplyingTime { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}