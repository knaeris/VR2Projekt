using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface IBlogCommentFactory
    {
        BlogCommentDTO Transform(BlogComment bc);
        BlogComment Transform(BlogCommentDTO dto);
       // BlogCommentDTO TransformWithBlogPosts(BlogComment bc);
    }
    public class BlogCommentFactory : IBlogCommentFactory
    {
        public BlogCommentDTO Transform(BlogComment bc)
        {
            return new BlogCommentDTO
            {
                BlogCommentId = bc.BlogCommentId,
                BlogCommentContent = bc.BlogCommentContent,
                ApplicationUserId = bc.ApplicationUserId


            };
        }

        public BlogComment Transform(BlogCommentDTO dto)
        {
            return new BlogComment()
            {
                BlogCommentId = dto.BlogCommentId,
                BlogCommentContent = dto.BlogCommentContent,
                ApplicationUserId = dto.ApplicationUserId


            };
        }
    }
}
