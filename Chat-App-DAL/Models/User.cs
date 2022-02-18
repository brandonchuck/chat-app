using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_App_DAL.Models
{
    // C# class to define the users table
    public class User
    {
        [Key]
        [Column("user_id")]
        public Guid UserId { get; private set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }


    public class Message
    {
        [Key]
        [Column("message_id")]
        public Guid MessageId { get; set; }

        [Column("user_id")]
        [ForeignKey("User")] // this FK is dependent on the User table UserId property
        public Guid UserId { get; set; }

        [Column("channel_id")]
        [ForeignKey("Channel")] // this FK is dependent on the User table UserId property
        public Guid ChannelId { get; set; }
    }

    public class Channel
    {
        [Key]
        [Column("channel_id")]
        public Guid ChannelId { get; set; }

        [Column("channel_name")]
        public string ChannelName { get; set; }
    }


}
