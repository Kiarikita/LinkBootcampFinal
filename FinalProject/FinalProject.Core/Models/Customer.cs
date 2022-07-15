using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Core.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        #region Basic Info

        [Required]
        [StringLength(50, ErrorMessage = "Ad 50 karakterden uzun olamaz")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Soyad 50 karakterden uzun olamaz")]
        [Display(Name = "Soyad")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email gerekli")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Resim gerekli")]
        [Display(Name = "Resim")]
        //[NotMapped]
        public /*IFormFile*/ string ImageURL { get; set; }
       

        [Required(ErrorMessage = "Telefon numarası gerekli")]
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Sağlanan telefon numarası geçerli değil")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Şehir bilgisi gerekli")]
        [Display(Name = "Şehir")]
        public string City { get; set; }

        #endregion
        //navigation property : one-to-many relationship with commercial activity
        public List<CommercialActivity> CommercialActivities { get; set; } = new List<CommercialActivity>();
    }
}
