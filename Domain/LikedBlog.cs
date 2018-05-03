using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class LikedBlog
    {
        public int LikedBlogId { get; set; }
        public Blog Blog { get; set; }
        public DateTime LikedBlogTime { get; set; }
    }
}
