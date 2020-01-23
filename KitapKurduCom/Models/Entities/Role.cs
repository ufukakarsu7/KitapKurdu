using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Ad")]
        [Column("Name")]
        public string RoleName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }


    }
}