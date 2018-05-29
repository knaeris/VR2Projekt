using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class FollowedBlog
    {
        public int FollowedBlogId { get; set; }
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }
        public DateTime FollowedBlogTime { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
