using DAL.App.EF.Repositories;
using DAL.App.Interfaces;
using DAL.App.Interfaces.Helpers;
using DAL.App.Interfaces.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.App.EF
{

    public class AppEFUnitOfWork : IAppUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IRepositoryProvider _repositoryProvider;
        public AppEFUnitOfWork(IDataContext dataContext, IRepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
            _applicationDbContext = dataContext as ApplicationDbContext;
            if(_applicationDbContext == null)
            {
                throw new NullReferenceException("No EF dbcontext found in uow");
            }
        }
        private IRepository<Blog>  _blogs;
        public IRepository<Blog> Blogs => GetEntityRepository<Blog>(); // _blogs = _blogs ?? new EFBlogRepository(_applicationDbContext);

        private IRepository<BlogPost> _blogPost;
        public IRepository<BlogPost> BlogPosts => GetEntityRepository<BlogPost>(); //_blogPost = _blogPost ?? new EFBlogPostRepository(_applicationDbContext);

        private IRepository<BlogComment> _blogComments;
        public IRepository<BlogComment> BlogComments => GetEntityRepository<BlogComment>();//_blogComments = _blogComments ?? new EFBlogCommentRepository(_applicationDbContext);

        private IRepository<BlogCategory> _blogCategories;
        public IRepository<BlogCategory> BlogCategories => GetEntityRepository<BlogCategory>(); // _blogCategories = _blogCategories ?? new EFBlogCategoryRepository(_applicationDbContext);

        private IRepository<BlogPostComment> _blogPostComments;
        public IRepository<BlogPostComment> BlogPostComments => GetEntityRepository<BlogPostComment>();

        private IRepository<FavoriteCategory> _favoriteCategories;
        public IRepository<FavoriteCategory> FavoriteCategories => GetEntityRepository<FavoriteCategory>();

        private IRepository<FollowedBlog> _followedBlogs;
        public IRepository<FollowedBlog> FollowedBlogs => GetEntityRepository<FollowedBlog>();

        private IRepository<LikedBlog> _likedBlogs;
        public IRepository<LikedBlog> LikedBlogs => GetEntityRepository<LikedBlog>();

        private IRepository<LikedBlogPost> _likedBlogPosts;
        public IRepository<LikedBlogPost> LikedBlogPosts => GetEntityRepository<LikedBlogPost>();

        private IRepository<ApplicationUser> _applicationUsers;
        public IRepository<ApplicationUser> ApplicationUsers => GetEntityRepository<ApplicationUser>();

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class
        {
            return _repositoryProvider.GetEntityRepository<TEntity>();
        }

        public TRepositoryInterface GetCustomRepository<TRepositoryInterface>() where TRepositoryInterface : class
        {
            return _repositoryProvider.GetCustomRepository<TRepositoryInterface>();
        }
    }
}
