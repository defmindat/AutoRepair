using Microsoft.AspNetCore.Identity;

namespace DomainModel
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}