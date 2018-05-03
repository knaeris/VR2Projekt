using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.App.EF.Repositories
{
    public class EFLikedBlogRepository : EFRepository<LikedBlog>, ILikedBlogRepository
    {
        public EFLikedBlogRepository(DbContext dataContext) : base(dataContext)
        {

        }
        public bool Exists(int id)
        {
            return RepositoryDbSet.Any(e => e.LikedBlogId == id);
        }
        public override LikedBlog Find(params object[] id)
        {
            return RepositoryDbSet
                .SingleOrDefault(x => (int)id[0] == x.LikedBlogId);
        }
    }
}
