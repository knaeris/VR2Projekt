using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.DTO
{
    public class BlogPostDTO
    {
        public int BlogPostId { get; set; }
        public string BlogPostTitle { get; set; }
        
        public string BlogPostContent { get; set; }
        public int BlogId { get; set; }
        //public string Blog { get; set; }
        public List<BlogCommentDTO> BlogComments { get; set; }
        public string ApplicationUserId { get; set; }

        public static BlogPostDTO CreateFromDomain(BlogPost bp)
        {
            return new BlogPostDTO()
            {
                BlogPostId = bp.BlogPostId,
                BlogPostTitle = bp.BlogPostTitle,
                BlogPostContent = bp.BlogPostContent,
                ApplicationUserId=bp.ApplicationUserId
                



            };
        }
        public static BlogPostDTO CreateFromDomainWithBlogComments ( BlogPost bp)
        {
            var blogPost = CreateFromDomain(bp);
            if (blogPost == null) return null;
            blogPost.BlogComments = bp?.BlogComments?
                .Select(c => BlogCommentDTO.CreateFromDomain(c)).ToList();
            return blogPost;
        }
    }
}
