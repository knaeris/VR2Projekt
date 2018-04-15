using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
  public  interface IBlogCommentService
    {
        List<BlogCommentDTO> GetAllBlogComments();
        BlogCommentDTO GetBlogCommentById(int blogCommentId);
        BlogCommentDTO AddNewBlogComment(BlogCommentDTO newBlogComment);
        BlogCommentDTO UpdateBlogComment(int blogCommentId, BlogCommentDTO blogComment);
        void DeleteBlogComment(int blogCommentId);
    }
}
