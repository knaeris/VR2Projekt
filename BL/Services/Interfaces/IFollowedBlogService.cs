using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
    public interface IFollowedBlogService
    {
        List<FollowedBlogDTO> GetAllFollowedBlogs();
        FollowedBlogDTO GetFollowedBlogById(int followedBlogId);
        FollowedBlogDTO AddNewFollowedBlog(FollowedBlogDTO newFollowedBlog);
        FollowedBlogDTO UpdateFollowedBlog(int followedBlogId, FollowedBlogDTO followedBlog);
        void DeleteFollowedBlog(int followedBlogId);
    }
}
