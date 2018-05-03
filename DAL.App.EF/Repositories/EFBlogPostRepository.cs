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
    public class EFBlogPostRepository : EFRepository<BlogPost>, IBlogPostRepository
    {
        public EFBlogPostRepository(DbContext dataContext) : base(dataContext)
        {

        }

        public bool Exists(int id)
        {
            return RepositoryDbSet.Any(e => e.BlogPostId == id);
        }

        public override BlogPost Find(params object[] id)
        {
            return RepositoryDbSet
                
                .Include(z=>z.BlogPostComments)
                .Include(x => x.Blog)
                .ThenInclude(y => y.BlogCategory)

                .SingleOrDefault(x => (int)id[0] == x.BlogPostId);
        }
    }
}
