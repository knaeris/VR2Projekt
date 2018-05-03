using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Factories
{
    public interface IFavoriteCategoryFactory
    {
        FavoriteCategoryDTO Transform(FavoriteCategory fc);
        FavoriteCategory Transform(FavoriteCategoryDTO dto);
     //   FavoriteCategoryDTO TransformWithCategories(FavoriteCategory fc);
    }
    public class FavoriteCategoryFactory : IFavoriteCategoryFactory
    {
        public FavoriteCategoryDTO Transform(FavoriteCategory fc)
        {
            return new FavoriteCategoryDTO
            {
                FavoriteCategoryId = fc.FavoriteCategoryId,
               // BlogCategories = fc?.BlogCategory?.BlogCategoryName
                //ApplicationUserId = fc.ApplicationUserId


            };
        }

        public FavoriteCategory Transform(FavoriteCategoryDTO dto)
        {
            return new FavoriteCategory()
            {
                FavoriteCategoryId = dto.FavoriteCategoryId

                //ApplicationUserId = dto.ApplicationUserId
            };
        }

       /* public FavoriteCategoryDTO TransformWithCategories(FavoriteCategory fc)
        {
            var dto = Transform(fc);
            if (dto == null) return null;
            dto.BlogCategory = fc?.BlogCategory?.Select(x => BlogDTO.CreateFromDomain(x)).ToList();
            return dto;
        }*/
    }
}