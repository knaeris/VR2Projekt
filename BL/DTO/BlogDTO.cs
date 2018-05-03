using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain;
using System.Linq;
namespace BL.DTO
{
    public class BlogDTO
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
      //  public int BlogCategoryId { get; set; }
       public string BlogCategory { get; set; }
        public List<BlogPostDTO> BlogPosts { get; set; }
        public List<BlogCommentDTO> BlogComments { get; set; }
        public string ApplicationUserId { get; set; }

        public static BlogDTO CreateFromDomain(Blog b)
        {
            if (b == null) return null;
            return new BlogDTO()
            {
                BlogId=b.BlogId,
                BlogTitle=b.BlogTitle,
                BlogDescription=b.BlogDescription,
                BlogCategory=b?.BlogCategory?.BlogCategoryName,
                ApplicationUserId = b.ApplicationUserId

            };
        }
        public static BlogDTO CreateFromDomainWithBlogPosts(Blog b)
        {
            var blog = CreateFromDomain(b);
            if (blog == null) return null;
            blog.BlogPosts = b?.BlogPosts?
                .Select(c => BlogPostDTO.CreateFromDomain(c)).ToList();
            return blog;
        }
        public static BlogDTO CreateFromDomainWithBlogComments(Blog b)
        {
            var blog = CreateFromDomain(b);
            if (blog == null) return null;
            blog.BlogComments = b?.BlogComments?
                .Select(c => BlogCommentDTO.CreateFromDomain(c)).ToList();
            return blog;
        }
    }
    
}
