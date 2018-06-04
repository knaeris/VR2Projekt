using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Filters;
using BL.DTO;
using BL.Services.Interfaces;
using DAL.App.EF;
using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VR2Projekt.Controllers.API
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/Blogs/{BlogId}/BlogPosts")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BlogPostsController : Controller
    {
        private readonly IBlogPostService _blogPostService;
        private readonly ApplicationDbContext _context;

        public BlogPostsController(IBlogPostService blogPostService, ApplicationDbContext context)
        {
            _blogPostService = blogPostService;
            _context = context;
        }
        /// <summary>
        /// Get all blogposts in blog by blogid
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns>blogpost in specific blog</returns>
        [AllowAnonymous]
        [HttpGet]
        public List<BlogPostDTO> GetAllBlogPostsInBlog(int blogId)
        {
            return _blogPostService.GetAllBlogPostsInBlog(blogId);
        }
        
        /// <summary>
        /// post new blogpost to database
        /// </summary>
        /// <param name="bp"></param>
        /// <returns>new blogpost</returns>
        [HttpPost]
     
         public IActionResult AddBlogPost([FromBody]BlogPostDTO bp)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userEmail = User.Identity.GetUserId();
            var appUser = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            bp.ApplicationUserId = appUser.Id;
            bp.ApplicationUser = userEmail;

            

            var newBlogPost = _blogPostService.AddNewBlogPost(bp);
            return CreatedAtAction("GetBlogPostById", new { id = newBlogPost.BlogPostId }, bp);
        }
        /// <summary>
        /// Method to get blogpost by id
        /// </summary>
        /// <param name="blogPostId"></param>
        /// <returns>Ok status with blogpost</returns>
        [AllowAnonymous]
        [HttpGet("{blogPostId:int}")]
        public IActionResult GetBlogPostById(int blogPostId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var r = _blogPostService.GetBlogPostById(blogPostId);
            if (r == null) return NotFound();
            return Ok(r);
        }
        /// <summary>
        /// Method to update blogpost
        /// </summary>
        /// <param name="blogPostId"></param>
        /// <param name="bp"></param>
        /// <returns>Ok status with updated blogpost</returns>
        [HttpPut("{blogPostId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBlogPost(int blogPostId, [FromBody]BlogPostDTO bp)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            bp.ApplicationUserId = User.Identity.GetUserId();
            var r = _blogPostService.UpdateBlogPost(blogPostId, bp);
            if (r == null) return NotFound();
            
            return Ok(r);
        }
        /// <summary>
        /// Deletes blogpost
        /// </summary>
        /// <param name="blogPostId"></param>
        [HttpDelete("{blogPostId:int}")]
        public void DeleteBlogPost(int blogPostId)
        {

            _blogPostService.DeleteBlogPost(blogPostId);
        }
    }
   
    
}