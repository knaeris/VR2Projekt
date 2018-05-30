using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
    public interface IBlogPostCommentService
    {
        List<BlogPostCommentDTO> GetAllBlogPostComments(int blogPostId);
        BlogPostCommentDTO GetBlogPostCommentById(int blogPostCommentId);
        BlogPostCommentDTO AddNewBlogPostComment(BlogPostCommentDTO newBlogPostComment);
        BlogPostCommentDTO UpdateBlogPostComment(int blogPostCommentId, BlogPostCommentDTO blogPostComment);
        void DeleteBlogPostComment(int blogPostCommentId);
    }
}
