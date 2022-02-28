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
        public Guid MessageId { get; set; }

        [Required]
        [Column("text")]
        public string Text { get; set; }

        // think of this as "I am grabbing the user_id from the User model and specifiying the relationship here"
        [ForeignKey("user_id")] // this FK is dependent on the User table UserId property
        public User User { get; set; }

        [ForeignKey("channel_id")] // this FK is dependent on the User table UserId property
        public Channel Channel { get; set; } // this is called a "navigation property"
    }
}
