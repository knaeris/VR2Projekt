using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
   public class FollowedBlogDTO
    {
        public int FollowedBlogId { get; set; }
        public string Blogs { get; set; }

        public static FollowedBlogDTO CreateFromDomain(FollowedBlog fb)
        {
            return new FollowedBlogDTO()
            {
                FollowedBlogId = fb.FollowedBlogId,
                Blogs = fb?.Blog?.BlogTitle





            };
        }
    }
}
