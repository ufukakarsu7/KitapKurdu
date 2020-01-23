using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        [ForeignKey("Customer")]
        public int ID { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        [Display(Name = "Onaylandı mı ?")]
        public bool IsConfirmed { get; set; }


        public virtual ICollection<ShoppingCartBook> ShoppingCartBook { get; set; }

    }
}