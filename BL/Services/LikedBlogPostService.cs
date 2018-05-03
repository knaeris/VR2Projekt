using BL.DTO;
using BL.Factories;
using BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class LikedBlogPostService : ILikedBlogPostService
    {
        private readonly DAL.App.Interfaces.IAppUnitOfWork _uow;
        private readonly ILikedBlogPostFactory _likedBlogPostFactory;
        public LikedBlogPostService(DAL.App.Interfaces.IAppUnitOfWork uow, ILikedBlogPostFactory likedBlogPostFactory)
        {
            _uow = uow;
            _likedBlogPostFactory = likedBlogPostFactory;
        }

        public LikedBlogPostDTO AddNewLikedBlogPost(LikedBlogPostDTO newLikedBlogPost)
        {
            var likedBlogPost = _likedBlogPostFactory.Transform(newLikedBlogPost);
            _uow.LikedBlogPosts.Add(likedBlogPost);
            _uow.SaveChanges();
            return newLikedBlogPost;

        }
#warning tegele deletega
        public void DeleteLikedBlogPost(int likedBlogPostId)
        {

            var likedBlogPost = _uow.LikedBlogPosts.Find(likedBlogPostId);
            _uow.LikedBlogPosts.Remove(likedBlogPost);
            _uow.SaveChanges();

        }

        public List<LikedBlogPostDTO> GetAllLikedBlogPosts()
        {
            return _uow.LikedBlogPosts.All().Select(b => LikedBlogPostDTO.CreateFromDomain(b)).ToList();
        }

        public LikedBlogPostDTO GetLikedBlogPostById(int likedBlogPostId)
        {
            return LikedBlogPostDTO.CreateFromDomain(_uow.LikedBlogPosts.Find(likedBlogPostId));
        }


        public LikedBlogPostDTO UpdateLikedBlogPost(int likedBlogPostId, LikedBlogPostDTO likedBlogPost)
        {
            var b = _likedBlogPostFactory.Transform(likedBlogPost);
            b.LikedBlogPostId = likedBlogPostId;
            _uow.LikedBlogPosts.Update(b);
            _uow.SaveChanges();
            return likedBlogPost;
        }

    }
}
