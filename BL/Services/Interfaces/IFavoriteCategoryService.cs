using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Interfaces
{
    public interface IFavoriteCategoryService
    {
        List<FavoriteCategoryDTO> GetAllFavoriteCategories();
        FavoriteCategoryDTO GetFavoriteCategoryById(int favoriteCategoryId);
        FavoriteCategoryDTO AddNewFavoriteCategory(FavoriteCategoryDTO newFavoriteCategory);
        FavoriteCategoryDTO UpdateFavoriteCategory(int favoriteCategoryId, FavoriteCategoryDTO favoriteCategory);
        void DeleteFavoriteCategory(int favoriteCategoryId);
    }
}
