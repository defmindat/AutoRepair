using Microsoft.AspNetCore.Identity;

namespace DomainModel
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Year { get; set; }
    }
}