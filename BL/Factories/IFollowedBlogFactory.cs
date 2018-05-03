using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface IFollowedBlogFactory
    {
        FollowedBlogDTO Transform(FollowedBlog fb);
        FollowedBlog Transform(FollowedBlogDTO dto);
        //   FavoriteCategoryDTO TransformWithCategories(FavoriteCategory fc);
    }
    public class FollowedBlogFactory : IFollowedBlogFactory
    {
        public FollowedBlogDTO Transform(FollowedBlog fb)
        {
            return new FollowedBlogDTO
            {
                FollowedBlogId = fb.FollowedBlogId,
                Blogs = fb?.Blog?.BlogTitle
                //ApplicationUserId = fc.ApplicationUserId


            };
        }

        public FollowedBlog Transform(FollowedBlogDTO dto)
        {
            return new FollowedBlog()
            {
                FollowedBlogId = dto.FollowedBlogId

                //ApplicationUserId = dto.ApplicationUserId
            };
        }
    }
}
