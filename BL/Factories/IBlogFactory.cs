using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Factories
{
   public interface IBlogFactory
    {
        BlogDTO Transform(Blog b);
        Blog Transform(BlogDTO dto);
        BlogDTO TransformWithBlogPosts(Blog b);
    }
    public class BlogFactory : IBlogFactory
    {
        public BlogDTO Transform(Blog b)
        {
            return new BlogDTO
            {
                BlogId = b.BlogId,
                BlogTitle = b.BlogTitle,
                BlogDescription = b.BlogDescription,
                ApplicationUserId = b.ApplicationUserId
                // BlogCategoryId = b.BlogCategoryId
            };
        }

        public Blog Transform(BlogDTO dto)
        {
            return new Blog()
            {
                BlogId=dto.BlogId,
                BlogTitle = dto.BlogTitle,
                BlogDescription = dto.BlogDescription,
                ApplicationUserId = dto.ApplicationUserId

            };
        }

        public BlogDTO TransformWithBlogPosts(Blog b)
        {
            var dto = Transform(b);
            if (dto == null) return null;
            dto.BlogPosts = b?.BlogPosts?.Select(x => BlogPostDTO.CreateFromDomain(x)).ToList();
            return dto;
        }
        public BlogDTO TransformWithBlogComments(Blog b)
        {
            var dto = Transform(b);
            if (dto == null) return null;
            dto.BlogComments = b?.BlogComments?.Select(x => BlogCommentDTO.CreateFromDomain(x)).ToList();
            return dto;
        }
    }
}
