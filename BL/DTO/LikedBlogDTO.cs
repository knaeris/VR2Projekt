using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
   public class LikedBlogDTO
    {
        public int LikedBlogId { get; set; }
        public Blog Blogs { get; set; }
        public DateTime LikedBlogTime { get; set; }
        public string ApplicationUserId { get; set; }

        public static LikedBlogDTO CreateFromDomain(LikedBlog lb)
        {
            return new LikedBlogDTO()
            {
                LikedBlogId = lb.LikedBlogId,
                
                LikedBlogTime=lb.LikedBlogTime,
                ApplicationUserId=lb.ApplcationUserId
            };
        }
    }
}
