using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
   public class BlogPostCommentDTO
    {

        public int BlogPostCommentId { get; set; }
        public string BlogPostCommentContent { get; set; }
        public string ApplicationUserId { get; set; }

        public static BlogPostCommentDTO CreateFromDomain(BlogPostComment bc)
        {
            if (bc == null) return null;
            return new BlogPostCommentDTO()
            {
                BlogPostCommentId = bc.BlogPostCommentId,
                BlogPostCommentContent = bc.BlogPostCommentContent,
                ApplicationUserId = bc.ApplicationUserId

            };
        }
    }
}
