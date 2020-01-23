using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }


    }
}