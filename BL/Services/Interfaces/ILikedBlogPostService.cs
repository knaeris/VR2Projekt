using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
    public interface ILikedBlogPostService
    {
        List<LikedBlogPostDTO> GetAllLikedBlogPosts();
        LikedBlogPostDTO GetLikedBlogPostById(int likedBlogPostId);
        LikedBlogPostDTO AddNewLikedBlogPost(LikedBlogPostDTO newLikedBlogPost);
        LikedBlogPostDTO UpdateLikedBlogPost(int likedBlogPostId, LikedBlogPostDTO likedBlogPost);
        void DeleteLikedBlogPost(int likedBlogPostId);
    }
}
