using System.ComponentModel.DataAnnotations;

namespace FinalProject.Core.Models
{
    public class CommercialActivity
    {
        [Key]
        public int Id { get; set; }

        #region Basic Info

        [Required]
        [StringLength(50, ErrorMessage = "Hizmet 50 karakterden uzun olamaz")]
        [Display(Name = "Hizmet")]
        public string Service { get; set; }

        [Required(ErrorMessage = "Fiyat bilgisi gerekli")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Tarih bilgisi gerekli")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tarih")]
        public DateTime ActivityDate { get; set; }

        #endregion
        //foreign key
        public int CustomerId { get; set; }
        //simple navigation property
        public Customer Customer { get; set; }


    }
}
