using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Cinsiyet")]
        public bool Gender { get; set; }
        [Required]
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }



    }
}