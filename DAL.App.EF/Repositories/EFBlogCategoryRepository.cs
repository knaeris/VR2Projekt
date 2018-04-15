using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using DAL.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.App.EF.Repositories
{
    public class EFBlogCategoryRepository : EFRepository<BlogCategory>, IBlogCategoryRepository
    {
        public EFBlogCategoryRepository(DbContext dataContext) : base(dataContext)
        {

        }

        public bool Exists(int id)
        {
            return RepositoryDbSet.Any(e => e.BlogCategoryId == id);
        }
        public override BlogCategory Find(params object[] id)
        {
            return RepositoryDbSet
                .Include(y => y.Blogs)
                .SingleOrDefault(x => (int)id[0] == x.BlogCategoryId);
        }
    }
}
