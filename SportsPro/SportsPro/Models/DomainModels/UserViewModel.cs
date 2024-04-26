using Microsoft.AspNetCore.Identity;
using SportsPro.Models.DomainModels;

namespace SportsPro.Models
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; } = null!;
        public IEnumerable<IdentityRole> Roles { get; set; } = null!;
    }
}
