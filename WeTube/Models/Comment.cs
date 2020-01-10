using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeTube.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }

        public int VideoId { get; set; }
        [ForeignKey("VideoId")]
        public virtual Video Video { get; set; }
    }
}