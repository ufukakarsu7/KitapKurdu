using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("CoverType")]
    public class CoverType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Cilt Tipi")]
        [Column("Name")]
        public string CoverTypeName { get; set; }

        public virtual ICollection<Book> Books { get; set; }


    }
}