using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
   public interface IBlogCategoryService
    {
        List<BlogCategoryDTO> GetAllBlogCategories();
        BlogCategoryDTO GetBlogCategoryById(int blogCategoryId);
        BlogCategoryDTO AddNewBlogCategory(BlogCategoryDTO newBlogCategory);
        BlogCategoryDTO UpdateBlogCategory(int blogCategoryId, BlogCategoryDTO blogCategory);
        void DeleteBlogCategory(int blogCategoryId);

    }
}
