using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("BookImage")]
    public class BookImage
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Resim")]
        public string ImageUrl { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }

        [NotMapped]
        public HttpPostedFileBase[] Files { get; set; }


    }
}