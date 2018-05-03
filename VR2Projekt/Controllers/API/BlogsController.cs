using System.Collections.Generic;
using BL.DTO;
using BL.Services.Interfaces;
using DAL.App.EF;
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
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;
        
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
           
        }
     
        [AllowAnonymous]
        [HttpGet]
        public List<BlogDTO> GetAllBlogs()
        {
           return _blogService.GetAllBlogs();
        }
       
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBlog([FromBody]BlogDTO b)
        {

            if (!ModelState.IsValid) return BadRequest();
           b.ApplicationUserId = User.Identity.GetUserId();
            var newBlog = _blogService.AddNewBlog(b);
            return CreatedAtAction("GetBlogById", new { id=newBlog.BlogId}, b);
        }
        [AllowAnonymous]
        [HttpGet("{blogId:int}")]
        public IActionResult GetBlogById(int blogId)
        {

            var r = _blogService.GetBlogById(blogId);
            if (r == null) return NotFound();
            return Ok(r);
        }
        [HttpPut("{blogId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBlog(int blogId, [FromBody] BlogDTO b)
        {
            if (!ModelState.IsValid) return BadRequest();
            b.ApplicationUserId = User.Identity.GetUserId();
            
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