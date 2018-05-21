using DAL.App.Interfaces.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.Interfaces
{
   public interface IAppUnitOfWork : IUnitOfWork
    {
       /*IBlogRepository Blogs { get; }
        IBlogPostRepository BlogPosts { get; }
        IBlogCommentRepository BlogComments { get; }
        IBlogCategoryRepository BlogCategories { get; }*/
        IRepository<Blog> Blogs { get; }
        IRepository<BlogPost> BlogPosts { get; }
        IRepository<BlogComment> BlogComments { get; }
        IRepository<BlogCategory> BlogCategories { get; }
        IRepository<BlogPostComment> BlogPostComments { get; }
        IRepository<FavoriteCategory> FavoriteCategories { get; }
        IRepository<FollowedBlog> FollowedBlogs { get; }
        IRepository<LikedBlog> LikedBlogs { get; }
        IRepository<LikedBlogPost> LikedBlogPosts { get; }
        IRepository<ApplicationUser> ApplicationUsers { get; }
    }
}
