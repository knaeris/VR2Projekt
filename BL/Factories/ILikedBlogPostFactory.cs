using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface ILikedBlogPostFactory
    {
        LikedBlogPostDTO Transform(LikedBlogPost fbp);
        LikedBlogPost Transform(LikedBlogPostDTO dto);
        //   FavoriteCategoryDTO TransformWithCategories(FavoriteCategory fc);
    }
    public class LikedBlogPostFactory : ILikedBlogPostFactory
    {
        public LikedBlogPostDTO Transform(LikedBlogPost fbp)
        {
            return new LikedBlogPostDTO
            {
                LikedBlogPostId = fbp.LikedBlogPostId,
                BlogPosts = fbp?.BlogPost?.BlogPostTitle
                //ApplicationUserId = fc.ApplicationUserId


            };
        }

        public LikedBlogPost Transform(LikedBlogPostDTO dto)
        {
            return new LikedBlogPost()
            {
                LikedBlogPostId = dto.LikedBlogPostId

                //ApplicationUserId = dto.ApplicationUserId
            };
        }
    }
}
