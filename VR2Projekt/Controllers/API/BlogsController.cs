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
     
      /// <summary>
      /// Method to get all blogs
      /// </summary>
      /// <returns>All blogs</returns>
       [HttpGet]
       [AllowAnonymous]
        public List<BlogDTO> GetAllBlogs()
        {
           return _blogService.GetAllBlogs();
        }
       

        /// <summary>
        /// Adds new blog to database
        /// </summary>
        /// <param name="b"></param>
        /// <returns>new blog</returns>
        [HttpPost]
       
        public IActionResult AddBlog([FromBody]BlogDTO b)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userEmail = User.Identity.GetUserId();
            var appUser = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            b.ApplicationUserId = appUser.Id;
           
            b.ApplicationUser = userEmail;
            var bc = _context.BlogCategories.FirstOrDefault(x => x.BlogCategoryId == b.BlogCategoryId);
            b.BlogCategory = bc.BlogCategoryName;
            var newBlog = _blogService.AddNewBlog(b);
            return CreatedAtAction("GetBlogById", new { id=newBlog.BlogId}, b);
        }
        
        /// <summary>
        /// Gets blog by id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns>Ok status with matching blog</returns>
        [HttpGet("{blogId:int}")]
        [AllowAnonymous]
        public IActionResult GetBlogById(int blogId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var r = _blogService.GetBlogById(blogId);
            if (r == null) return NotFound();
            return Ok(r);
        }
        /// <summary>
        /// Updates blog
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="b"></param>
        /// <returns>Ok status with updated blog</returns>
        [AllowAnonymous]
        [HttpPut("{blogId:int}")]
       
        public IActionResult UpdateBlog(int blogId, [FromBody] BlogDTO b)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
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
        /// <summary>
        /// Deletes blog
        /// </summary>
        /// <param name="blogId"></param>
        [HttpDelete("{blogId:int}")]
      
        public void DeleteBlog(int blogId)
        {
            var blog = _blogService.GetBlogById(blogId);
            var userEmail = User.Identity.GetUserId();
            var appUser = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            if (blog.ApplicationUserId == appUser.Id)
                _blogService.DeleteBlog(blogId);
            else
                 BadRequest();
        }
    }
}