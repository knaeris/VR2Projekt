using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

using Microsoft.AspNetCore.Identity;

namespace Domain
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Ńickname { get; set; }
       
        public List<FollowedBlog> FollowedBlogs { get; set; }
        public List<LikedBlog> LikedBlogs { get; set; }
        public List<LikedBlogPost> LikedBlogPosts { get; set; }
        public List<FavoriteCategory> FavoriteCategories { get; set; }

        
    }
}
