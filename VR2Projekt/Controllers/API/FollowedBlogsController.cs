using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BL.DTO;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;

namespace VR2Projekt.Controllers.API
{
    [Produces("application/json")]
    [Route("api/FollowedBlogs")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    
    public class FollowedBlogsController : Controller
    {
        private readonly IFollowedBlogService _followedBlogService;
        
        public FollowedBlogsController(IFollowedBlogService followedBlogService)
        {
            _followedBlogService = followedBlogService;
           
        }
     
        [AllowAnonymous]
        [HttpGet]
        public List<FollowedBlogDTO> GetAllFollowedBlogs()
        {
           return _followedBlogService.GetAllFollowedBlogs();
        }
       
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFollowedBlog([FromBody]FollowedBlogDTO fb)
        {

            if (!ModelState.IsValid) return BadRequest();
          // fb.ApplicationUserId = User.Identity.GetUserId();
            var newBlog = _followedBlogService.AddNewFollowedBlog(fb);
            return CreatedAtAction("GetFollowedBlogById", new { id=newBlog.FollowedBlogId }, fb);
        }
        [AllowAnonymous]
        [HttpGet("{followedBlogId:int}")]
        public IActionResult GetFollowedBlogById(int followedBlogId)
        {

            var r = _followedBlogService.GetFollowedBlogById(followedBlogId);
            if (r == null) return NotFound();
            return Ok(r);
        }
        [HttpPut("{followedBlogId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateFollowedBlog(int followedBlogId, [FromBody] FollowedBlogDTO fb)
        {
            if (!ModelState.IsValid) return BadRequest();
            //fb.ApplicationUserId = User.Identity.GetUserId();
            
            var r = _followedBlogService.UpdateFollowedBlog(followedBlogId, fb);
            if (r == null) return NotFound();
            
            
            return Ok(r);
        }
        [HttpDelete("{followedBlogId:int}")]
        public void DeleteFollowedBlog(int followedBlogId)
        {
           
             _followedBlogService.DeleteFollowedBlog(followedBlogId); 
        }
    
    }
}