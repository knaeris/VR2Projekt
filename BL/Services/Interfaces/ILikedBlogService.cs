using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
    public interface ILikedBlogService
    {
        List<LikedBlogDTO> GetAllLikedBlogs();
        LikedBlogDTO GetLikedBlogById(int likedBlogId);
        LikedBlogDTO AddNewLikedBlog(LikedBlogDTO newLikedBlog);
        LikedBlogDTO UpdateLikedBlog(int likedBlogId, LikedBlogDTO likedBlog);
        void DeleteLikedBlog(int likedBlogId);
    }
}
