using System.ComponentModel.DataAnnotations;

namespace FinalProject.Core.Models
{
    public class UserRefreshToken
    {
        [Key]
        public string UserId { get; set; }

        [StringLength(200)]
        public string Code { get; set; }

        public DateTime Expiration { get; set; }
    }
}
