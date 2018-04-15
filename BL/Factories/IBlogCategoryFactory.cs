using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Factories
{
    public interface IBlogCategoryFactory
    {
        BlogCategoryDTO Transform(BlogCategory bc);
        BlogCategory Transform(BlogCategoryDTO dto);
        BlogCategoryDTO TransformWithBlogs(BlogCategory bc);
    }
    public class BlogCategoryFactory : IBlogCategoryFactory
    {
        public BlogCategoryDTO Transform(BlogCategory bc)
        {
            return new BlogCategoryDTO
            {
                BlogCategoryId = bc.BlogCategoryId,
                BlogCategoryName = bc.BlogCategoryName,
                ApplicationUserId=bc.ApplicationUserId


            };
        }

        public BlogCategory Transform(BlogCategoryDTO dto)
        {
            return new BlogCategory()
            {
                BlogCategoryId = dto.BlogCategoryId,
                BlogCategoryName = dto.BlogCategoryName,
                ApplicationUserId = dto.ApplicationUserId
            };
        }

        public BlogCategoryDTO TransformWithBlogs(BlogCategory bc)
        {
            var dto = Transform(bc);
            if (dto == null) return null;
            dto.Blogs = bc?.Blogs?.Select(x => BlogDTO.CreateFromDomain(x)).ToList();
            return dto;
        }
    }
}
