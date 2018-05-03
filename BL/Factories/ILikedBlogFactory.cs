using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface ILikedBlogFactory
    {
        LikedBlogDTO Transform(LikedBlog fb);
        LikedBlog Transform(LikedBlogDTO dto);
        //   FavoriteCategoryDTO TransformWithCategories(FavoriteCategory fc);
    }
    public class LikedBlogFactory : ILikedBlogFactory
    {
        public LikedBlogDTO Transform(LikedBlog fb)
        {
            return new LikedBlogDTO
            {
                LikedBlogId = fb.LikedBlogId,
                Blogs = fb?.Blog?.BlogTitle,
                LikedBlogTime=fb.LikedBlogTime
                //ApplicationUserId = fc.ApplicationUserId


            };
        }

        public LikedBlog Transform(LikedBlogDTO dto)
        {
            return new LikedBlog()
            {
                LikedBlogId = dto.LikedBlogId,
                LikedBlogTime=dto.LikedBlogTime

                //ApplicationUserId = dto.ApplicationUserId
            };
        }
    }
}
