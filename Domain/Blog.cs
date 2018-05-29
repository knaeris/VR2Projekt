
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        [MaxLength(128)]
        public string BlogTitle { get; set; }
        [MaxLength(1024)]
        public string BlogDescription { get; set; }
        public virtual List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
        public int Rating { get; set; }
        public virtual List<BlogComment> BlogComments { get; set; }
        public int? BlogCategoryId { get; set; }
        [ForeignKey("BlogCategoryId")]
        public virtual BlogCategory BlogCategory { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public List<FollowedBlog> FollowedBlogs { get; set; } = new List<FollowedBlog>();
        public List<LikedBlog> LikedBlogs { get; set; } = new List<LikedBlog>();
        
     
        
        
    }
}
