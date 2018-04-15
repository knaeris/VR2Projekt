using BL.DTO;
using BL.Factories;
using BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class BlogCategoryService : IBlogCategoryService
    {
        private readonly DAL.App.Interfaces.IAppUnitOfWork _uow;
        private readonly IBlogCategoryFactory _blogCategoryFactory;
        public BlogCategoryService(DAL.App.Interfaces.IAppUnitOfWork uow, IBlogCategoryFactory blogCategoryFactory)
        {
            _uow = uow;
            _blogCategoryFactory = blogCategoryFactory;
        }
        public BlogCategoryDTO AddNewBlogCategory(BlogCategoryDTO newBlogCategory)
        {
            var blogCategory = _blogCategoryFactory.Transform(newBlogCategory);
            _uow.BlogCategories.Add(blogCategory);
            _uow.SaveChanges();
            return newBlogCategory;
        }

        public void DeleteBlogCategory(int blogCategoryId)
        {
            var blogCategory = _uow.BlogCategories.Find(blogCategoryId);
            _uow.BlogCategories.Remove(blogCategory);
            _uow.SaveChanges();
        }

        public List<BlogCategoryDTO> GetAllBlogCategories()
        {
            return _uow.BlogCategories.All().Select(b => BlogCategoryDTO.CreateFromDomain(b)).ToList();
        }

        public BlogCategoryDTO GetBlogCategoryById(int blogCategoryId)
        {
            return BlogCategoryDTO.CreateFromDomain(_uow.BlogCategories.Find(blogCategoryId));
        }

        public BlogCategoryDTO UpdateBlogCategory(int blogCategoryId, BlogCategoryDTO blogCategory)
        {
            var bc = _blogCategoryFactory.Transform(blogCategory);
            bc.BlogCategoryId = blogCategoryId;
            _uow.BlogCategories.Update(bc);
            _uow.SaveChanges();
            return blogCategory;
        }
    }
}
