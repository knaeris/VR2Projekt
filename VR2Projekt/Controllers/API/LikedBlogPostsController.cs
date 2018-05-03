using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.DTO;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VR2Projekt.Controllers.API
{
    [Produces("application/json")]
    [Route("api/LikedBlogPosts")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LikedBlogPostsController : Controller
    {
        private readonly ILikedBlogPostService _likedBlogPostService;

        public LikedBlogPostsController(ILikedBlogPostService likedBlogPostService)
        {
            _likedBlogPostService = likedBlogPostService;

        }

        [AllowAnonymous]
        [HttpGet]
        public List<LikedBlogPostDTO> GetAllLikedBlogPosts()
        {
            return _likedBlogPostService.GetAllLikedBlogPosts();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLikedBlogPost([FromBody]LikedBlogPostDTO lb)
        {

            if (!ModelState.IsValid) return BadRequest();
            //lb.ApplicationUserId = User.Identity.GetUserId();
            var newLikedBlogPost = _likedBlogPostService.AddNewLikedBlogPost(lb);
            return CreatedAtAction("GetLikedBlogPostById", new { id = newLikedBlogPost.LikedBlogPostId }, lb);
        }
        [AllowAnonymous]
        [HttpGet("{likedBlogPostId:int}")]
        public IActionResult GetLikedBlogPostById(int likedBlogPostId)
        {

            var r = _likedBlogPostService.GetLikedBlogPostById(likedBlogPostId);
            if (r == null) return NotFound();
            return Ok(r);
        }
        [HttpPut("{likedBlogPostId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateLikedBlogPost(int likedBlogPostId, [FromBody] LikedBlogPostDTO lb)
        {
            if (!ModelState.IsValid) return BadRequest();
            //lb.ApplicationUserId = User.Identity.GetUserId();

            var r = _likedBlogPostService.UpdateLikedBlogPost(likedBlogPostId, lb);
            if (r == null) return NotFound();


            return Ok(r);
        }
        [HttpDelete("{likedBlogPostId:int}")]
        public void DeleteLikedBlogPost(int likedBlogPostId)
        {

            _likedBlogPostService.DeleteLikedBlogPost(likedBlogPostId);
        }
    }
}