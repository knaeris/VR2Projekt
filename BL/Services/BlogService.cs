using System.Collections.Generic;
using BL.DTO;
using System.Linq;
using BL.Factories;
using BL.Services.Interfaces;
using Domain;

namespace BL.Services
{
    public class BlogService : IBlogService
    {
        private readonly DAL.App.Interfaces.IAppUnitOfWork _uow;
        private readonly IBlogFactory _blogFactory; 
        public BlogService(DAL.App.Interfaces.IAppUnitOfWork uow,IBlogFactory blogFactory)
        {
            _uow = uow;
            _blogFactory = blogFactory;
        }

        public BlogDTO AddNewBlog(BlogDTO newBlog)
        {
            var blog = _blogFactory.Transform(newBlog);
            _uow.Blogs.Add(blog);
            _uow.SaveChanges();
            return newBlog;

        }

        public void DeleteBlog(int blogId)
        {
            
            var blog = _uow.Blogs.Find(blogId);
            _uow.Blogs.Remove(blog);
            _uow.SaveChanges();
           
        }

        public List<BlogDTO> GetAllBlogs()
        {
            return _uow.Blogs.All().Select(b => BlogDTO.CreateFromDomain(b)).ToList();
        }

        public BlogDTO GetBlogById(int blogId)
        {
            return BlogDTO.CreateFromDomain(_uow.Blogs.Find(blogId));
        }


        public BlogDTO UpdateBlog(int blogId, BlogDTO blog)
        {
            var b = _blogFactory.Transform(blog);
            b.BlogId = blogId;
            _uow.Blogs.Update(b);
            _uow.SaveChanges();
            return blog;
        }
        
    }
}
