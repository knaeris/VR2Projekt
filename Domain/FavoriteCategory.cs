using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class FavoriteCategory
    {
        public int FavoriteCategoryId { get; set; }
        public int? BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
    }
}
