using BL.DTO;
using BL.Factories;
using BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class LikedBlogService : ILikedBlogService
    {
        private readonly DAL.App.Interfaces.IAppUnitOfWork _uow;
        private readonly ILikedBlogFactory _likedBlogFactory;
        public LikedBlogService(DAL.App.Interfaces.IAppUnitOfWork uow, ILikedBlogFactory likedBlogFactory)
        {
            _uow = uow;
            _likedBlogFactory = likedBlogFactory;
        }

        public LikedBlogDTO AddNewLikedBlog(LikedBlogDTO newLikedBlog)
        {
            var likedBlog = _likedBlogFactory.Transform(newLikedBlog);
            _uow.LikedBlogs.Add(likedBlog);
            _uow.SaveChanges();
            return newLikedBlog;

        }
#warning tegele deletega
        public void DeleteLikedBlog(int likedBlogId)
        {

            var likedBlog = _uow.LikedBlogs.Find(likedBlogId);
            _uow.LikedBlogs.Remove(likedBlog);
            _uow.SaveChanges();

        }

        public List<LikedBlogDTO> GetAllLikedBlogs()
        {
            return _uow.LikedBlogs.All().Select(b => LikedBlogDTO.CreateFromDomain(b)).ToList();
        }

        public LikedBlogDTO GetLikedBlogById(int LikedBlogId)
        {
            return LikedBlogDTO.CreateFromDomain(_uow.LikedBlogs.Find(LikedBlogId));
        }


        public LikedBlogDTO UpdateLikedBlog(int LikedBlogId, LikedBlogDTO LikedBlog)
        {
            var b = _likedBlogFactory.Transform(LikedBlog);
            b.LikedBlogId = LikedBlogId;
            _uow.LikedBlogs.Update(b);
            _uow.SaveChanges();
            return LikedBlog;
        }

    }
}
