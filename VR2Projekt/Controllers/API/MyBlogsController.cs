using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
    [Route("api/MyBlogs")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MyBlogsController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IAppUnitOfWork _uow;
        private readonly ApplicationDbContext _context;
    
        public MyBlogsController(IBlogService blogService, ApplicationDbContext context, IAppUnitOfWork uow)
        {
            _blogService = blogService;
            _uow = uow;
            _context = context;
        }
        [HttpGet]

        public IEnumerable<Blog> GetMyBlogs()
        {
            var userEmail = User.Identity.GetUserId();
            var appUser = _context.Users.FirstOrDefault(x => x.Email == userEmail);
            var myBlogs = _uow.Blogs.All().Where(x => x.ApplicationUserId == appUser.Id);
            
            return myBlogs;

        }
    }
}