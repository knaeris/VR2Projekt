using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using DAL.App.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VR2Projekt.Controllers.API
{
    [Produces("application/json")]
    
    public class BlogsInCategoriesController : Controller
    {
        
        private readonly IAppUnitOfWork _uow;
        private readonly ApplicationDbContext _context;

        public BlogsInCategoriesController( ApplicationDbContext context, IAppUnitOfWork uow)
        {
           
            _uow = uow;
            _context = context;
        }
        [HttpGet]
        [Route("api/Blogcategories/{blogCategoryId}/Blogs")]
        public IEnumerable<Blog> GetBlogsInCategories(int blogCategoryId)
        {
            
           
            var myBlogs = _uow.Blogs.All().Where(x => x.BlogCategoryId == blogCategoryId);

            return myBlogs;

        }

    }
}