using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using BL.DTO;
using System.Linq;
namespace BL.DTO
{
    public class BlogCategoryDTO
    {
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
        public List<BlogDTO> Blogs { get; set; }
        public string ApplicationUserId { get; set; }

        public static BlogCategoryDTO CreateFromDomain(BlogCategory bc)
        {
            if (bc == null) return null;
            return new BlogCategoryDTO()
            {
                BlogCategoryId = bc.BlogCategoryId,
                BlogCategoryName = bc.BlogCategoryName,
                ApplicationUserId = bc.ApplicationUserId

            };
        }
        public static BlogCategoryDTO CreateFromDomainWithBlogs(BlogCategory bc)
        {
            var blogCategory = CreateFromDomain(bc);
            if (blogCategory == null) return null;
            blogCategory.Blogs = bc?.Blogs?
                .Select(x => BlogDTO.CreateFromDomain(x)).ToList();
            return blogCategory;
        }
    }
}
