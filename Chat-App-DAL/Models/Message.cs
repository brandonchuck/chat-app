using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_App_DAL.Models
{
    public class Message
    {
        //public Message(int userId, string text, int channelId)
        //{
        //    Text = text;
        //    User.UserId = userId;
        //    Channel.ChannelId = channelId;
        //}

        [Key]
        [Column("message_id")]
        public int MessageId { get; set; }

        [Required]
        [Column("text")]
        public string Text { get; set; }

        [ForeignKey("user_id")] // this FK is dependent on the User table UserId property
        public User User { get; set; }

        [ForeignKey("channel_id")] // this FK is dependent on the User table UserId property
        public Channel Channel { get; set; } // this is called a "navigation property"
    }
}
