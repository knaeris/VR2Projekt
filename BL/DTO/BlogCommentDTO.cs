using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
    public class BlogCommentDTO
    {
        public int BlogCommentId { get; set; }
        public string BlogCommentContent { get; set; }
        public string ApplicationUserId { get; set; }

        public static BlogCommentDTO CreateFromDomain(BlogComment bc)
        {
            if (bc == null) return null;
            return new BlogCommentDTO()
            {
                BlogCommentId = bc.BlogCommentId,
                BlogCommentContent = bc.BlogCommentContent,
                ApplicationUserId = bc.ApplicationUserId

            };
        }
    }
}
