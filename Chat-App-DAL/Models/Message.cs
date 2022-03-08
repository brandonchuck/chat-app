using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_App_DAL.Models
{
    public class Message
    {
        [Key]
        [Column("message_id")]
        public int MessageId { get; set; }

        [Required]
        [Column("text")]
        public string Text { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; } // establishes 1-to-many relationship w/ User

        [ForeignKey("channel_id")]
        public Channel Channel { get; set; } // establishes 1-to-many relationship w/ Channel

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
