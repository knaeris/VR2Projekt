using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
   public class LikedBlogPostDTO
    {
        public int LikedBlogPostId { get; set; }
        public string BlogPosts { get; set; }


        public static LikedBlogPostDTO CreateFromDomain(LikedBlogPost lbp)
        {
            return new LikedBlogPostDTO()
            {
                LikedBlogPostId = lbp.LikedBlogPostId,
                BlogPosts = lbp?.BlogPost?.BlogPostTitle
            };
        }
    }
}
