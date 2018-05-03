using BL.DTO;
using BL.Factories;
using BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class FavoriteCategoryService : IFavoriteCategoryService
    {
        private readonly DAL.App.Interfaces.IAppUnitOfWork _uow;
        private readonly IFavoriteCategoryFactory _favoriteCategoryFactory;
        public FavoriteCategoryService(DAL.App.Interfaces.IAppUnitOfWork uow, IFavoriteCategoryFactory favoriteCategoryFactory)
        {
            _uow = uow;
            _favoriteCategoryFactory = favoriteCategoryFactory;
        }
        public FavoriteCategoryDTO AddNewFavoriteCategory(FavoriteCategoryDTO newFavoriteCategory)
        {
            var favoriteCategory = _favoriteCategoryFactory.Transform(newFavoriteCategory);
            _uow.FavoriteCategories.Add(favoriteCategory);
            _uow.SaveChanges();
            return newFavoriteCategory;
        }

        public void DeleteFavoriteCategory(int favoriteCategoryId)
        {
            var favoriteCategory = _uow.FavoriteCategories.Find(favoriteCategoryId);
            _uow.FavoriteCategories.Remove(favoriteCategory);
            _uow.SaveChanges();
        }

        public List<FavoriteCategoryDTO> GetAllFavoriteCategories()
        {
            return _uow.FavoriteCategories.All().Select(b => FavoriteCategoryDTO.CreateFromDomain(b)).ToList();
        }

        public FavoriteCategoryDTO GetFavoriteCategoryById(int favoriteCategoryId)
        {
            return FavoriteCategoryDTO.CreateFromDomain(_uow.FavoriteCategories.Find(favoriteCategoryId));
        }

        public FavoriteCategoryDTO UpdateFavoriteCategory(int favoriteCategoryId, FavoriteCategoryDTO favoriteCategory)
        {
            var fc = _favoriteCategoryFactory.Transform(favoriteCategory);
            fc.FavoriteCategoryId = favoriteCategoryId;
            _uow.FavoriteCategories.Update(fc);
            _uow.SaveChanges();
            return favoriteCategory;
        }
    }
}
