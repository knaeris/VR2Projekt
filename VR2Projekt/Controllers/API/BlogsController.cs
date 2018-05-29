using System.Collections.Generic;
using System.Linq;
using BL.DTO;
using BL.Services.Interfaces;
using DAL.App.EF;
using DAL.App.Interfaces;
using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VR2Projekt.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Blogs")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IAppUnitOfWork _uow;
        private readonly ApplicationDbContext _context;

        public BlogsController(IBlogService blogService, ApplicationDbContext context, IAppUnitOfWork uow)
        {
            _blogService = blogService;
            _uow = uow;
            _context = context;
        }
     
      
       [HttpGet]
       [AllowAnonymous]
        public List<BlogDTO> GetAllBlogs()
        {
           return _blogService.GetAllBlogs();
        }
       
       /* [HttpGet]
       // [Route("/myblogs")]
        public IEnumerable<Blog> GetMyBlogs()
        {
            var userEmail = User.Identity.GetUserId();
            var appUser = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            var myBlogs = _uow.Blogs.All().Where(x=>x.ApplicationUserId==appUser.Id);
            return myBlogs;
        }*/


        [HttpPost]
       
        public IActionResult AddBlog([FromBody]BlogDTO b)
        {

            if (!ModelState.IsValid) return BadRequest();
            var userEmail = User.Identity.GetUserId();
            var appUser = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            b.ApplicationUserId = appUser.Id;
            b.ApplicationUser = userEmail;
            var bc = _context.BlogCategories.FirstOrDefault(x => x.BlogCategoryId == b.BlogCategoryId);
            b.BlogCategory = bc.BlogCategoryName;
            var newBlog = _blogService.AddNewBlog(b);
            return CreatedAtAction("GetBlogById", new { id=newBlog.BlogId}, b);
        }
        

        [HttpGet("{blogId:int}")]
        [AllowAnonymous]
        public IActionResult GetBlogById(int blogId)
        {

            var r = _blogService.GetBlogById(blogId);
            if (r == null) return NotFound();
            return Ok(r);
        }
        [AllowAnonymous]
        [HttpPut("{blogId:int}")]
       // [ValidateAntiForgeryToken]
        public IActionResult UpdateBlog(int blogId, [FromBody] BlogDTO b)
        {
            if (!ModelState.IsValid) return BadRequest();
            var userEmail = User.Identity.GetUserId();
            var appUser = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            b.ApplicationUserId = appUser.Id;
            b.ApplicationUser = userEmail;
            var bc = _context.BlogCategories.FirstOrDefault(x => x.BlogCategoryId == b.BlogCategoryId);
            b.BlogCategory = bc.BlogCategoryName;

            var r = _blogService.UpdateBlog(blogId, b);
            if (r == null) return NotFound();
            
            
            return Ok(r);
        }
        [HttpDelete("{blogId:int}")]
        public void DeleteBlog(int blogId)
        {
           
             _blogService.DeleteBlog(blogId); 
        }
    }
}