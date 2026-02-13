using System.ComponentModel.DataAnnotations.Schema;

namespace KDWalks.API.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string Email { get; set; }
        // Navigation Properity
        public  List<User_Role> UsersRoles { get; set; }

    }
}
