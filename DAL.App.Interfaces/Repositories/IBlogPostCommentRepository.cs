﻿using DAL.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.Interfaces.Repositories
{
    public interface IBlogPostCommentRepository : IRepository<BlogPostComment>
    {
        bool Exists(int id);

    }
}
