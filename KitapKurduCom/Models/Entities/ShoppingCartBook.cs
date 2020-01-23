using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using KitapKurdu.UI.Models.Entity;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("ShoppingCartBook")]
    public class ShoppingCartBook
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CartID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookID { get; set; }

        public int Quantity { get; set; }

        public virtual Book Book { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}