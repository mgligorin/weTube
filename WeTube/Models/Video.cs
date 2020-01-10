using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WeTube.Helpers;

namespace WeTube.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public Enums.Visibility Visibility { get; set; }
        public bool CommentAvailability { get; set; }
        public bool RatioAvailability { get; set; }
        public bool IsBlocked { get; set; }
        public int Views { get; set; }
        public DateTime CreatedOn { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
    }
}