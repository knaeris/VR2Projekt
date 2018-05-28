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
   public class EFBlogRepository : EFRepository<Blog>, IBlogRepository
    {
        public EFBlogRepository(DbContext dataContext) : base(dataContext)
        {

        }

        public bool Exists(int id)
        {
            return RepositoryDbSet.Any(e => e.BlogId == id);
        }
        public override Blog Find(params object[] id)
        {
            return RepositoryDbSet
                .Include(y=>y.BlogCategory)
                .Include(x => x.BlogPosts)
                .Include(z=>z.BlogComments)
                .Include(a=>a.ApplicationUser)
                .SingleOrDefault(x => (int)id[0] == x.BlogId);
        }
    }
}
