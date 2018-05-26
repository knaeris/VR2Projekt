using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Filters;
using BL.DTO;
using BL.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VR2Projekt.Controllers.API
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/BlogPosts")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BlogPostsController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostsController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;

        }
        [AllowAnonymous]
        [HttpGet]
        public List<BlogPostDTO> GetAllBlogPosts()
        {
            return _blogPostService.GetAllBlogPosts();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[EnableCors(origins: "localhost:3000", headers: "*", methods: "*")]
        public IActionResult AddBlogPost([FromBody]BlogPostDTO bp)
        {
            bp.ApplicationUserId = User.Identity.GetUserId();
            if (!ModelState.IsValid) return BadRequest();

            var newBlogPost = _blogPostService.AddNewBlogPost(bp);
            return CreatedAtAction("GetBlogPostById", new { id = newBlogPost.BlogPostId }, bp);
        }
        [AllowAnonymous]
        [HttpGet("{blogPostId:int}")]
        public IActionResult GetBlogPostById(int blogPostId)
        {

            var r = _blogPostService.GetBlogPostById(blogPostId);
            if (r == null) return NotFound();
            return Ok(r);
        }
        [HttpPut("{blogPostId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBlogPost(int blogPostId, [FromBody]BlogPostDTO bp)
        {
            bp.ApplicationUserId = User.Identity.GetUserId();
            if (!ModelState.IsValid) return BadRequest();
            var r = _blogPostService.UpdateBlogPost(blogPostId, bp);
            if (r == null) return NotFound();
            
            return Ok(r);
        }
        [HttpDelete("{blogPostId:int}")]
        public void DeleteBlogPost(int blogPostId)
        {

            _blogPostService.DeleteBlogPost(blogPostId);
        }
    }
   
    
}