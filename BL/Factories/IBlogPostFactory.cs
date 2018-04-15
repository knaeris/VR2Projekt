using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Factories
{
    public interface IBlogPostFactory
    {
        BlogPostDTO Transform(BlogPost bp);
        BlogPost Transform(BlogPostDTO dto);
        BlogPostDTO TransformWithBlogComments(BlogPost bp);
    }
    public class BlogPostFactory : IBlogPostFactory
    {
        public BlogPostDTO Transform(BlogPost bp)
        {
            return new BlogPostDTO
            {
                BlogPostId = bp.BlogPostId,
                BlogPostTitle=bp.BlogPostTitle,
                BlogPostContent=bp.BlogPostContent,
                ApplicationUserId = bp.ApplicationUserId
            };
        }

        public BlogPost Transform(BlogPostDTO dto)
        {
            return new BlogPost()
            {
                BlogPostId = dto.BlogPostId,
                BlogPostTitle = dto.BlogPostTitle,
                BlogPostContent = dto.BlogPostContent,
                ApplicationUserId = dto.ApplicationUserId
            };
        }

        public BlogPostDTO TransformWithBlogComments(BlogPost bp)
        {
            var dto = Transform(bp);
            if (dto == null) return null;
            dto.BlogComments = bp?.BlogComments?.Select(x => BlogCommentDTO.CreateFromDomain(x)).ToList();
            return dto;
        }
    }
}
