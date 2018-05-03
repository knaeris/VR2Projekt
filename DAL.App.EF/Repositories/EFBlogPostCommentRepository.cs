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
    public class EFBlogPostCommentRepository : EFRepository<BlogPostComment>, IBlogPostCommentRepository
    {
        public EFBlogPostCommentRepository(DbContext dataContext) : base(dataContext)
        {

        }

        public bool Exists(int id)
        {
            return RepositoryDbSet.Any(e => e.BlogPostCommentId == id);
        }
        public override BlogPostComment Find(params object[] id)
        {
            return RepositoryDbSet
                .Include(y => y.BlogPost)
                .SingleOrDefault(x => (int)id[0] == x.BlogPostCommentId);
        }
    }
}