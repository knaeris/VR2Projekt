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
    [Route("api/FavoriteCategories")]
   
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public class FavoriteCategoriesController : Controller
        {
            private readonly IFavoriteCategoryService _favoriteCategoryService;
            public FavoriteCategoriesController(IFavoriteCategoryService favoriteCategoryService)
            {
                _favoriteCategoryService = favoriteCategoryService;

            }

            [AllowAnonymous]

            [HttpGet]
            public List<FavoriteCategoryDTO> GetFavoriteCategories()
            {
                return _favoriteCategoryService.GetAllFavoriteCategories();
            }

            [AllowAnonymous]
            [HttpGet("{favoriteCategoryId:int}")]
            public IActionResult GetFavoriteCategoryById([FromRoute] int favoriteCategoryId)
            {
                var r = _favoriteCategoryService.GetFavoriteCategoryById(favoriteCategoryId);
                if (r == null) return NotFound();
                return Ok(r);
            }



            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult AddFavoriteCategory([FromBody] FavoriteCategoryDTO favoriteCategory)
            {
                //favoriteCategory.ApplicationUserId = User.Identity.GetUserId();
                if (!ModelState.IsValid) return BadRequest();

                var newFavoriteCategory = _favoriteCategoryService.AddNewFavoriteCategory(favoriteCategory);


                return CreatedAtAction("GetFavoriteCategoryById", new { id = newFavoriteCategory.FavoriteCategoryId }, favoriteCategory);
            }
            [HttpPut("{favoriteCategoryId:int}")]
            [ValidateAntiForgeryToken]
            public IActionResult UpdateFavoriteCategory(int favoriteCategoryId, [FromBody] FavoriteCategoryDTO fc)
            {

              //  bc.ApplicationUserId = User.Identity.GetUserId();
                if (!ModelState.IsValid) return BadRequest();
                var r = _favoriteCategoryService.UpdateFavoriteCategory(favoriteCategoryId, fc);
                if (r == null) return NotFound();


                return Ok(r);
            }
            [HttpDelete("{avoriteCategoryId:int}")]
            [ValidateAntiForgeryToken]
            public void DeleteFavoriteCategory(int favoriteCategoryId)
            {

                _favoriteCategoryService.DeleteFavoriteCategory(favoriteCategoryId);
            }
        }
    }
