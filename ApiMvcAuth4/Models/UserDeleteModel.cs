using System.ComponentModel.DataAnnotations;

namespace ApiMvcAuth4.Models
{
    public class UserDeleteModel
    {
        // [Required]
        // [EmailAddress]
        // public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}