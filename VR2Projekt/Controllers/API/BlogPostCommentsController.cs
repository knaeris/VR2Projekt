using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.DTO;
using BL.Services.Interfaces;
using DAL.App.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VR2Projekt.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Blogs/{blogId}/BlogPosts/{blogPostId}/BlogPostComments")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BlogPostCommentsController : Controller
    {
        private readonly IBlogPostCommentService _blogPostCommentService;
        private readonly ApplicationDbContext _context;

        public BlogPostCommentsController(IBlogPostCommentService blogPostCommentService, ApplicationDbContext context)
        {
            _blogPostCommentService = blogPostCommentService;
            _context = context;

        }
        [AllowAnonymous]
        [HttpGet]

        public List<BlogPostCommentDTO> GetAllBlogPostComments(int blogPostId)
        {
            return _blogPostCommentService.GetAllBlogPostComments(blogPostId);
        }
        [AllowAnonymous]
        [HttpGet("{blogPostCommentId:int}")]

        public IActionResult GetBlogPostCommentById(int blogPostCommentId)
        {
            var r = _blogPostCommentService.GetBlogPostCommentById(blogPostCommentId);
            if (r == null) return NotFound();
            return Ok(r);
        }
        //[AllowAnonymous]
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult AddNewBlogPostComment([FromBody] BlogPostCommentDTO bc)
        {
             
            if (!ModelState.IsValid) return BadRequest();
            var userEmail = User.Identity.GetUserId();
            var appUser = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            bc.ApplicationUserId = appUser.Id;
            var newBlogPostComment = _blogPostCommentService.AddNewBlogPostComment(bc);

            return CreatedAtAction("GetBlogPostCommentById", new { id = newBlogPostComment.BlogPostCommentId }, bc);
        }
        [HttpPut("{blogPostCommentId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBlogPostComment(int blogPostCommentId, [FromBody] BlogPostCommentDTO bc)
        {
            bc.ApplicationUserId = User.Identity.GetUserId();
            if (!ModelState.IsValid) return BadRequest();
            var r = _blogPostCommentService.UpdateBlogPostComment(blogPostCommentId, bc);

            return Ok(r);
        }
        [HttpDelete("{blogPostCommentId:int}")]
        public void DeleteBlogPostComment(int blogPostCommentId)
        {

            _blogPostCommentService.DeleteBlogPostComment(blogPostCommentId);
        }
    }
}