using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapKurdu.UI.Models.Entity
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name ="Kitap Adı")]
        [Column("Name")]
        public string BookName { get; set; }
        [Required]
        [Display(Name = "Kitap Açıklama")]
        [AllowHtml]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Kitap Fiyat")]
        public decimal UnitPrice { get; set; }
        [Required]
        [Display(Name = "Stok Durumu")]
        public int UnitsInStock { get; set; }
        [Required]
        [Display(Name = "Üretim Durumu")]
        public bool ProductionState { get; set; }
        [Required]
        [Display(Name = "Sayfa Sayısı")]
        public string PageNumber { get; set; }
        [Required]
        [Display(Name = "Yayın Tarihi")]
        public DateTime PublishDate { get; set; }

        [ForeignKey("CoverType")]
        public int CoverTypeID { get; set; }
        public virtual CoverType CoverType { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; }

        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }

        [ForeignKey("Translator")]
        public int TranslatorID { get; set; }
        public virtual Translator Translator { get; set; }

        [ForeignKey("Language")]
        public int LanguageID { get; set; }
        public virtual Language Language { get; set; }

        public virtual ICollection<BookImage> BookImages { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<ShoppingCartBook> ShoppingCartBook { get; set; }



    }
}