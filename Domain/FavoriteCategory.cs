using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class FavoriteCategory
    {
        public int FavoriteCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
        
    }
}
