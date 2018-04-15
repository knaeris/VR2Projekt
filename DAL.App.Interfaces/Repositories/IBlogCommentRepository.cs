using DAL.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.Interfaces.Repositories
{
   public interface IBlogCommentRepository : IRepository<BlogComment>
    {
        bool Exists(int id);

    }
}
