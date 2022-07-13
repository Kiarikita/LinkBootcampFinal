using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace FinalProject.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string City { get; set; }

        //[Display(Name = "Kullanıcı Adı")]
        //[Required(ErrorMessage = "Kullanıcı adı bilgisi zorunludur!")]
        //public string Username { get; set; }

        //[Display(Name = "Şifre")]
        //[Required(ErrorMessage = "Şifre zorunludur!")]
        //public string Password { get; set; }

        //[Display(Name = "Rol")]
        //[Required(ErrorMessage = "Rol bilgisi zorunludur!")]
        //public string Role { get; set; }
    }
}
