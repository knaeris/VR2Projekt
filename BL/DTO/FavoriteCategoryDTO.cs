using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
    public class FavoriteCategoryDTO
    {
        public int FavoriteCategoryId {get;set;}
        //public string BlogCategories { get; set; }

        public static FavoriteCategoryDTO CreateFromDomain(FavoriteCategory fc)
        {
            return new FavoriteCategoryDTO()
            {
                FavoriteCategoryId = fc.FavoriteCategoryId,
              /*  BlogCategories
                = fc?.BlogCategory?.BlogCategoryName
                */




            };
        }
       
    }
}

