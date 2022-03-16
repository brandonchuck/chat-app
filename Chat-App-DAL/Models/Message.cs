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
        public int user_id { get; set; }

        [ForeignKey("channel_id")]
        public Channel Channel { get; set; } // establishes 1-to-many relationship w/ Channel
        public int channel_id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
