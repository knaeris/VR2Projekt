using DAL.App.Interfaces.Helpers;
using DAL.EF.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.EF.Helpers
{
    public class EFRepositoryProvider : IRepositoryProvider
    {
        // private readonly IDataContext _dataContext;
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly IRepositoryFactory _repositoryFactory;
        private readonly Dictionary<Type, object> _repositoryCache = new Dictionary<Type, object>();
        public EFRepositoryProvider(IDataContext dataContext, IRepositoryFactory repositoryFactory)
        {
            // _dataContext = dataContext;
            _repositoryFactory = repositoryFactory;
            _applicationDbContext = dataContext as ApplicationDbContext;
            if (_applicationDbContext == null)
            {
                throw new NullReferenceException("No EF dbcontext found in uow");
            }
        }
        public TRepository GetCustomRepository<TRepository>() where TRepository : class
        {
            return GetOrMakeRepository<TRepository>(_repositoryFactory.GetCustomRepositoryFactory<TRepository>());
        }
        /*private TRepository GetOrMakeCustomRepository<TRepository>(Func<IDataContext, object> factory) 
            where TRepository:class
        {
            if(_repositoryCache.TryGetValue(typeof(TRepository), out var repo))
            {
                return (TRepository) repo;
            }
            if (factory == null)
            {
                throw new ArgumentNullException($"no standard factory found{typeof(TRepository).Name}");
            }

            repo = factory(_applicationDbContext);
            _repositoryCache.Add(typeof(TRepository), repo);
            return (TRepository)repo;

        }*/

        public IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class
        {
            return GetOrMakeRepository<IRepository<TEntity>>
                (_repositoryFactory.GetStandardRepositoryFactory<TEntity>());

        }
        private TRepository GetOrMakeRepository<TRepository>(Func<IDataContext, object> factory)
           where TRepository : class
        {
            if (_repositoryCache.TryGetValue(typeof(TRepository), out var repo))
            {
                return (TRepository)repo;
            }

            if (factory == null)
            {
                throw new ArgumentNullException($"No factory found for type {typeof(TRepository).Name}");
            }

            repo = factory(_applicationDbContext);

            _repositoryCache.Add(typeof(TRepository), repo);

            return (TRepository)repo;

        }
    }
}
