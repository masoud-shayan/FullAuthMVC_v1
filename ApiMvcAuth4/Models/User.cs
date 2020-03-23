using Microsoft.AspNetCore.Identity;

namespace ApiMvcAuth4.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}