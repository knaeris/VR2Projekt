using BL.DTO;
using BL.Factories;
using BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class BlogPostService:IBlogPostService
    {
        private readonly DAL.App.Interfaces.IAppUnitOfWork _uow;
        private readonly IBlogPostFactory _blogPostFactory;
        public BlogPostService(DAL.App.Interfaces.IAppUnitOfWork uow, IBlogPostFactory blogPostFactory)
        {
            _uow = uow;
            _blogPostFactory = blogPostFactory;
        }

        public BlogPostDTO AddNewBlogPost(BlogPostDTO newBlogPost)
        {
            var blogPost = _blogPostFactory.Transform(newBlogPost);
            _uow.BlogPosts.Add(blogPost);
            _uow.SaveChanges();
            return newBlogPost;
        }

        public void DeleteBlogPost(int blogPostId)
        {
            var blogPost = _uow.BlogPosts.Find(blogPostId);
            _uow.BlogPosts.Remove(blogPost);
            _uow.SaveChanges();
        }

        public List<BlogPostDTO> GetAllBlogPosts()
        {
            return _uow.BlogPosts.All().Select(b => BlogPostDTO.CreateFromDomain(b)).ToList();
        }

        public BlogPostDTO GetBlogPostById(int blogPostId)
        {
            return BlogPostDTO.CreateFromDomain(_uow.BlogPosts.Find(blogPostId));
        }

        public BlogPostDTO UpdateBlogPost(int blogPostId, BlogPostDTO blogPost)
        {
            var bp = _blogPostFactory.Transform(blogPost);
            bp.BlogPostId = blogPostId;    
            _uow.BlogPosts.Update(bp);                               
            _uow.SaveChanges();
            return blogPost;
        }
        
    }
}
