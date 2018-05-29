using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class BlogCategory
    {
        [Key]
        public int BlogCategoryId { get; set; }
        [MaxLength(128)]
        public string BlogCategoryName { get; set; }
        public virtual List<Blog> Blogs { get; set; } = new List<Blog>();
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<FavoriteCategory> FavoriteCategories { get; set; } = new List<FavoriteCategory>();
    }
}
