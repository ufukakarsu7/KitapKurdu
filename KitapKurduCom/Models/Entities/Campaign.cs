using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Campaign")]
    public class Campaign
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Resim")]
        public string ImageURL { get; set; }
        [Required]
        [Display(Name = "Başlangıç Tarihi")]
        [DataType(DataType.Date)]
        public DateTime DateOfStart { get; set; }
        [Required]
        [Display(Name = "Bitiş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime DateOfFinish { get; set; }
        [Required]
        [Display(Name = "İndirim Oran")]
        public float DiscountRate { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}