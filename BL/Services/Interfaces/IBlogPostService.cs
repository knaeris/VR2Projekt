using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
    public interface IBlogPostService
    {
        List<BlogPostDTO> GetAllBlogPostsInBlog(int blogId);
        BlogPostDTO GetBlogPostById(int blogPostId);
        BlogPostDTO AddNewBlogPost(BlogPostDTO newBlogPost);
        BlogPostDTO UpdateBlogPost(int blogPostiId, BlogPostDTO blogPost);
        void DeleteBlogPost(int blogPostId);
    }
}
