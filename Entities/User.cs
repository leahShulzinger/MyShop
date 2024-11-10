using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {   
        [EmailAddress,Required]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "firstName Can be between 4 till 8 chars", MinimumLength = 4), Required]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "lastName Can be between 4 till 8 chars", MinimumLength = 4), Required]
        public string LastName { get; set; }
        public int UserId { get; set; }

        [StringLength(20, ErrorMessage = "password Can be between 4 till 20 chars", MinimumLength = 4), Required]
        public string Password { get; set; }

    }
}
