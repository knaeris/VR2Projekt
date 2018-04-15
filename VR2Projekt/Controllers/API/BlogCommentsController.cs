using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BL.DTO;
using BL.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.WindowsAzure.Storage;

namespace VR2Projekt.Controllers.API
{
    [Produces("application/json")]
    [Route("api/BlogComments")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BlogCommentsController : Controller
    {
        private readonly IBlogCommentService _blogCommentService;

        public BlogCommentsController(IBlogCommentService blogCommentService)
        {
            _blogCommentService = blogCommentService;

        }
        [AllowAnonymous]
        [HttpGet]
       
        public List<BlogCommentDTO> GetAllBlogComments()
        {
            return _blogCommentService.GetAllBlogComments();
        }
        [AllowAnonymous]
        [HttpGet("{blogCommentId:int}")]

        public IActionResult GetBlogCommentById( int blogCommentId)
        {
            var r = _blogCommentService.GetBlogCommentById(blogCommentId);
            if (r == null) return NotFound();
            return Ok(r);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewBlogComment([FromBody] BlogCommentDTO bc)
        {
            bc.ApplicationUserId = User.Identity.GetUserId();
            if (!ModelState.IsValid) return BadRequest();

            var newBlogComment = _blogCommentService.AddNewBlogComment(bc);
           
            return CreatedAtAction("GetBlogCommentById", new { id = newBlogComment.BlogCommentId }, bc);
        }
        [HttpPut("{blogCommentId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBlogComment(int blogCommentId, [FromBody] BlogCommentDTO bc)
        {
            bc.ApplicationUserId = User.Identity.GetUserId();
            if (!ModelState.IsValid) return BadRequest();
            var r = _blogCommentService.UpdateBlogComment(blogCommentId, bc);

            return Ok(r);
        }
        [HttpDelete("{blogCommentId:int}")]
        public void DeleteBlogComment(int blogCommentId)
        {

            _blogCommentService.DeleteBlogComment(blogCommentId);
        }
    }
}