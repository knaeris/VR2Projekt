using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BL.DTO;
using BL.Services.Interfaces;
using DAL.App.EF;
using DAL.App.Interfaces;
using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;

namespace VR2Projekt.Controllers.API
{
    [Produces("application/json")]
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MyBlogsController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IAppUnitOfWork _uow;
        private readonly ApplicationDbContext _context;
        private readonly ILikedBlogService _likedBlogService;


        public MyBlogsController(ILikedBlogService likedblogService, ApplicationDbContext context, IAppUnitOfWork uow)
        {
            _likedBlogService = likedblogService;
            _uow = uow;
            _context = context;
        }
        [HttpGet]
        [Route("api/MyBlogs")]
        public IEnumerable<Blog> GetMyBlogs()
        {
            var userEmail = User.Identity.GetUserId();
            var appUser = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            var myBlogs = _uow.Blogs.All().Where(x => x.ApplicationUserId == appUser.Id);
            
            return myBlogs;

        }
        [HttpPost]
        [Route("api/LikedBlogs")]
        public IActionResult LikeBlog([FromBody]LikedBlog blog)
        {
            return null;
        }
    }
}