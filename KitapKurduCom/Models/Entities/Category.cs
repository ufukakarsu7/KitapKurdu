using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Ad")]
        public string CategoryName { get; set; }
        [Required]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}