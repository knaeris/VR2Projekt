using BL.DTO;
using BL.Factories;
using BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class FollowedBlogService : IFollowedBlogService
    {
        private readonly DAL.App.Interfaces.IAppUnitOfWork _uow;
        private readonly IFollowedBlogFactory _followedBlogFactory;
        public FollowedBlogService(DAL.App.Interfaces.IAppUnitOfWork uow, IFollowedBlogFactory followedBlogFactory)
        {
            _uow = uow;
            _followedBlogFactory = followedBlogFactory;
        }

        public FollowedBlogDTO AddNewFollowedBlog(FollowedBlogDTO newFollowedBlog)
        {
            var followedBlog = _followedBlogFactory.Transform(newFollowedBlog);
            _uow.FollowedBlogs.Add(followedBlog);
            _uow.SaveChanges();
            return newFollowedBlog;

        }
#warning tegele deletega
        public void DeleteFollowedBlog(int followedBlogId)
        {

            var followedBlog = _uow.FollowedBlogs.Find(followedBlogId);
            _uow.Blogs.Remove(followedBlog);
            _uow.SaveChanges();

        }

        public List<FollowedBlogDTO> GetAllFollowedBlogs()
        {
            return _uow.FollowedBlogs.All().Select(b => FollowedBlogDTO.CreateFromDomain(b)).ToList();
        }

        public FollowedBlogDTO GetFollowedBlogById(int followedBlogId)
        {
            return FollowedBlogDTO.CreateFromDomain(_uow.FollowedBlogs.Find(followedBlogId));
        }


        public FollowedBlogDTO UpdateFollowedBlog(int followedBlogId, FollowedBlogDTO followedBlog)
        {
            var b = _followedBlogFactory.Transform(followedBlog);
            b.FollowedBlogId = followedBlogId;
            _uow.FollowedBlogs.Update(b);
            _uow.SaveChanges();
            return followedBlog;
        }

    }
}
