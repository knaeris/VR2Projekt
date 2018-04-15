using DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;
namespace DAL.App.Interfaces.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        //check for entity existance by pk value
        bool Exists(int id);
        
    }
}
