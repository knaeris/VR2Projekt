﻿using DAL.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.Interfaces.Repositories
{

    public interface IBlogCategoryRepository : IRepository<BlogCategory>
    {
        bool Exists(int id);
    }
}
