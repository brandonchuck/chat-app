using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_App_DAL.Models
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } 
    }

}
