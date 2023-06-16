using System.ComponentModel.DataAnnotations;

namespace UserLogging.Models.User
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
