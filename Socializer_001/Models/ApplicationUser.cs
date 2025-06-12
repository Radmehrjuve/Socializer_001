using Microsoft.AspNetCore.Identity;

namespace Socializer_001.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? FamilyName { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? Field { get; set; }
        public string? EnteredYear { get; set; }
        public short? sex { get; set; }
        public DateOnly? ArrivalDate { get; set; }

    }
}
