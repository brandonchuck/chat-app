﻿using System.ComponentModel.DataAnnotations;
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

        [Required]
        [Column("password")]
        public string Password { get; set; }
    }


    




}
