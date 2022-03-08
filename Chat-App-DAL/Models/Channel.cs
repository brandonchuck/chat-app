using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_App_DAL.Models
{
    public class Channel
    {
        [Key]
        [Column("channel_id")]
        public int ChannelId { get; set; }

        [Required]
        [Column("channel_name")]
        public string ChannelName { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
