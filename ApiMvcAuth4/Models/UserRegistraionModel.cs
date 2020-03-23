using System.ComponentModel.DataAnnotations;

namespace ApiMvcAuth4.Models
{
    public class UserRegistraionModel
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [Required(ErrorMessage = " Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password" , ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
    }
}