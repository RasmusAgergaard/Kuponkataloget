using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using static Kuponkatalog.Models.Enums;

namespace Kuponkatalog.Models
{
    public class Message
    {
        public Message()
        {
            TimeSend = DateTime.Now;
            Status = messageStatus.Unread;
        }

        [BindNever]
        public int MessageId { get; set; }

        public DateTime TimeSend { get; set; }
        public messageStatus Status { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "Your name is required")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Your subject is required")]
        public string Subject { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = "Your message is required")]
        public string Content { get; set; }
    }
}
