using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Presentation.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập địa chỉ email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mời nhập pasword")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}