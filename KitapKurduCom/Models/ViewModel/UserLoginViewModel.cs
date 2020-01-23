using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KitapKurdu.UI.Models.ViewModel
{
    public class UserLoginViewModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifreyi girmediniz!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}