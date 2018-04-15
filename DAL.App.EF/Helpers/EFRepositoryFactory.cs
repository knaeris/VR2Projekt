using DAL.App.EF.Repositories;
using DAL.App.Interfaces.Helpers;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.EF.Helpers
{
    public class EFRepositoryFactory : IRepositoryFactory
    {
        private readonly Dictionary<Type, Func<IDataContext, object>> _customRepositoryFactories
            = GetCustomRepoFactories();
        private static Dictionary<Type, Func<IDataContext, object>> GetCustomRepoFactories() {
            return new Dictionary<Type, Func<IDataContext, object>>()
            {
                {typeof(IBlogRepository), dataContext => new EFBlogRepository(dataContext as ApplicationDbContext) },
                {typeof(IBlogPostRepository), dataContext => new EFBlogPostRepository(dataContext as ApplicationDbContext) },
                {typeof(IBlogCommentRepository), dataContext => new EFBlogCommentRepository(dataContext as ApplicationDbContext) },
                {typeof(IBlogCategoryRepository), dataContext => new EFBlogCategoryRepository(dataContext as ApplicationDbContext) }
            };
        }
        public Func<IDataContext, object> GetCustomRepositoryFactory<TRepoInterface>() where TRepoInterface : class
        {
            
            _customRepositoryFactories.TryGetValue(typeof(TRepoInterface), out Func<IDataContext, object> factory);
            return factory;
        }

        public Func<IDataContext, object> GetStandardRepositoryFactory<TEntity>() where TEntity : class
        {
            return (dataContext) => new EFRepository<TEntity>(dataContext as ApplicationDbContext);
        }
    }
}
