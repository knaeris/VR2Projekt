using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class LikedBlogPost
    {
        public int LikedBlogPostId { get; set; }
        public int? BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public DateTime LikedBlogPostTime { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
