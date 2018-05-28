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
       
        public List<BlogPostCommentDTO> BlogPostComments { get; set; }
        public string ApplicationUserId { get; set; }
        public string ApplicationUser { get; set; }

        public static BlogPostDTO CreateFromDomain(BlogPost bp)
        {
            return new BlogPostDTO()
            {
                BlogPostId = bp.BlogPostId,
                BlogPostTitle = bp.BlogPostTitle,
                BlogPostContent = bp.BlogPostContent,
                BlogId=bp.BlogId,
                ApplicationUser = bp?.ApplicationUser?.Email,
                ApplicationUserId = bp?.ApplicationUserId




            };
        }
        public static BlogPostDTO CreateFromDomainWithBlogPostComments ( BlogPost bp)
        {
            var blogPost = CreateFromDomain(bp);
            if (blogPost == null) return null;
            blogPost.BlogPostComments = bp?.BlogPostComments?
                .Select(c => BlogPostCommentDTO.CreateFromDomain(c)).ToList();
            return blogPost;
        }
    }
}
