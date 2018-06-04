using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Route("api/BlogCategories")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BlogCategoriesController : Controller
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public BlogCategoriesController(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;

        }
        [AllowAnonymous]
        
        [HttpGet]
        public List<BlogCategoryDTO> GetBlogCategories()
        {
            return _blogCategoryService.GetAllBlogCategories();
        }

        [AllowAnonymous]
        [HttpGet("{blogCategoryId:int}")]
        public IActionResult GetBlogCategoryById( int blogCategoryId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var r = _blogCategoryService.GetBlogCategoryById(blogCategoryId);
            if (r == null) return NotFound();
            return Ok(r);
        }

        
        
        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public IActionResult AddBlogCategory([FromBody] BlogCategoryDTO blogCategory)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            blogCategory.ApplicationUserId = User.Identity.GetUserId();
            var newBlogCategory = _blogCategoryService.AddNewBlogCategory(blogCategory);
           return CreatedAtAction("GetBlogCategory", new { id = newBlogCategory.BlogCategoryId }, blogCategory);
        }

        [HttpPut("{blogCategoryId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBlogCategory(int blogCategoryId, [FromBody] BlogCategoryDTO bc)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (blogCategoryId != bc.BlogCategoryId) return BadRequest();
            bc.ApplicationUserId = User.Identity.GetUserId();
            
            var r = _blogCategoryService.UpdateBlogCategory(blogCategoryId, bc);
            if (r == null) return NotFound();


            return Ok(r);
        }

        [AllowAnonymous]
        [HttpDelete("{blogCategoryId:int}")]
       // [ValidateAntiForgeryToken]
        public void DeleteBlogCategory(int blogCategoryId)
        {
            
            _blogCategoryService.DeleteBlogCategory(blogCategoryId);
        }
    }
}