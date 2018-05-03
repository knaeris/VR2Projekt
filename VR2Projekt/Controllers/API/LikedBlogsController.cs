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
    [Route("api/LikedBlogs")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LikedBlogsController : Controller
    {
        private readonly ILikedBlogService _likedBlogService;

        public LikedBlogsController(ILikedBlogService likedBlogService)
        {
            _likedBlogService = likedBlogService;

        }

        [AllowAnonymous]
        [HttpGet]
        public List<LikedBlogDTO> GetAllLikedBlogs()
        {
            return _likedBlogService.GetAllLikedBlogs();
        }

        [AllowAnonymous]
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public IActionResult AddLikedBlog([FromBody]LikedBlogDTO lb)
        {

            if (!ModelState.IsValid) return BadRequest();
            //lb.ApplicationUserId = User.Identity.GetUserId();
            var newLikedBlog = _likedBlogService.AddNewLikedBlog(lb);
            return CreatedAtAction("GetLikedBlogById", new { id = newLikedBlog.LikedBlogId }, lb);
        }
        [AllowAnonymous]
        [HttpGet("{likedBlogId:int}")]
        public IActionResult GetLikedBlogById(int likedBlogId)
        {

            var r = _likedBlogService.GetLikedBlogById(likedBlogId);
            if (r == null) return NotFound();
            return Ok(r);
        }
        [HttpPut("{likedBlogId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateLikedBlog(int likedBlogId, [FromBody] LikedBlogDTO lb)
        {
            if (!ModelState.IsValid) return BadRequest();
            //lb.ApplicationUserId = User.Identity.GetUserId();

            var r = _likedBlogService.UpdateLikedBlog(likedBlogId, lb);
            if (r == null) return NotFound();


            return Ok(r);
        }
        [HttpDelete("{likedBlogId:int}")]
        public void DeleteLikedBlog(int likedBlogId)
        {

            _likedBlogService.DeleteLikedBlog(likedBlogId);
        }
    }
}