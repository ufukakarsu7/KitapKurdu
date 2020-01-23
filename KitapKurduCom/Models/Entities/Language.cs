using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Language")]
    public class Language
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Ad")]
        [Column("Name")]
        public string LanguageName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}