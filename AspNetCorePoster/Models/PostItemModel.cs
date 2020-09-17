using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCorePoster.Models
{
    public class PostItem
    {
        public string Text { get; set; }
        public DateTimeOffset PostDate { get; set; }
        public string UserId { get; set; }
    }
}