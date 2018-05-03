using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface IBlogPostCommentFactory
    {
        BlogPostCommentDTO Transform(BlogPostComment bc);
        BlogPostComment Transform(BlogPostCommentDTO dto);
      
    }
    public class BlogPostCommentFactory : IBlogPostCommentFactory
    {
        public BlogPostCommentDTO Transform(BlogPostComment bc)
        {
            return new BlogPostCommentDTO
            {
                BlogPostCommentId = bc.BlogPostCommentId,
                BlogPostCommentContent = bc.BlogPostCommentContent,
                ApplicationUserId = bc.ApplicationUserId


            };
        }

        public BlogPostComment Transform(BlogPostCommentDTO dto)
        {
            return new BlogPostComment()
            {
                BlogPostCommentId = dto.BlogPostCommentId,
                BlogPostCommentContent = dto.BlogPostCommentContent,
                ApplicationUserId = dto.ApplicationUserId


            };
        }

       
    }
}
