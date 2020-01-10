using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WeTube.Helpers;

namespace WeTube.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Enums.Role Role { get; set; }

        public Guid AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual ApplicationUser User { get; set; }

        public bool IsBlocked { get; set; }
        public ICollection<AppUser> Subscribers { get; set; }
        public ICollection<LikeRatio> VideoLikes { get; set; }
        public ICollection<LikeRatio> CommentLikes { get; set; }
    }
}