using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeTube.Models
{
    public class LikeRatio
    {
        public int Id { get; set; }
        public bool IsLiked { get; set; }
        public DateTime CreatedOn { get; set; }

        public int? VideoId { get; set; }
        [ForeignKey("VideoId")]
        public virtual Video Video { get; set; }

        public int? CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
    }
}