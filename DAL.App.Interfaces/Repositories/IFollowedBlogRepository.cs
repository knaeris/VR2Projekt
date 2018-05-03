using DAL.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.Interfaces.Repositories
{
    public interface IFollowedBlogRepository : IRepository<FollowedBlog>
    {
        bool Exists(int id);
    }
}
