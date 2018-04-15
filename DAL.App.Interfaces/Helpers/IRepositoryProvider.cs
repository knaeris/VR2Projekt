using DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.Interfaces.Helpers
{
   public interface IRepositoryProvider
    {
        IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class;
        TRepository GetCustomRepository<TRepository>() where TRepository : class;
    }
}
