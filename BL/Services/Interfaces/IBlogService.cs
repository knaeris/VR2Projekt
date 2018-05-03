using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
    public interface IBlogService
    {
        List<BlogDTO> GetAllBlogs();
        BlogDTO GetBlogById(int blogId);
        BlogDTO AddNewBlog(BlogDTO newBlog);
        BlogDTO UpdateBlog(int blogId, BlogDTO blog);
        void  DeleteBlog(int blogId);

      
    }
}
