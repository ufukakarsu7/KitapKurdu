using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Değerlendirme")]
        public int Star { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }
        public virtual Book Book  { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }


    }
}