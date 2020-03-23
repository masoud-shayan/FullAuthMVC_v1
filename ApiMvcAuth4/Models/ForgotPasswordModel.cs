using System.ComponentModel.DataAnnotations;

namespace ApiMvcAuth4.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}