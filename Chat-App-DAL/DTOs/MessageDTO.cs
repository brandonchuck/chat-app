﻿namespace Chat_App_DAL.DTOs
{
    public class MessageDTO
    {
        public int MessageId { get; set; } // working on including MessageId from Message entity 
        public string Text { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }   
    }
}
