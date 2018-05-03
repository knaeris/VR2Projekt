using BL.DTO;
using BL.Factories;
using BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class BlogPostCommentService : IBlogPostCommentService
    {
        private readonly DAL.App.Interfaces.IAppUnitOfWork _uow;
        private readonly IBlogPostCommentFactory _blogPostCommentFactory;

        public BlogPostCommentService(DAL.App.Interfaces.IAppUnitOfWork uow, IBlogPostCommentFactory blogPostCommentFactory)
        {
            _uow = uow;
            _blogPostCommentFactory = blogPostCommentFactory;
        }
        public BlogPostCommentDTO AddNewBlogPostComment(BlogPostCommentDTO newBlogPostComment)
        {
            var blogPostComment = _blogPostCommentFactory.Transform(newBlogPostComment);
            _uow.BlogPostComments.Add(blogPostComment);
            _uow.SaveChanges();
            return newBlogPostComment;
        }

        public void DeleteBlogPostComment(int blogPostCommentId)
        {
            var blogPostComment = _uow.BlogPostComments.Find(blogPostCommentId);
            _uow.BlogPostComments.Remove(blogPostComment);
            _uow.SaveChanges();
        }

        public List<BlogPostCommentDTO> GetAllBlogPostComments()
        {
            return _uow.BlogPostComments.All().Select(b => BlogPostCommentDTO.CreateFromDomain(b)).ToList();
        }

        public BlogPostCommentDTO GetBlogPostCommentById(int blogPostCommentId)
        {
            return BlogPostCommentDTO.CreateFromDomain(_uow.BlogPostComments.Find(blogPostCommentId));
        }

        public BlogPostCommentDTO UpdateBlogPostComment(int blogPostCommentId, BlogPostCommentDTO blogPostComment)
        {
            var bc = _blogPostCommentFactory.Transform(blogPostComment);
            bc.BlogPostCommentId = blogPostCommentId;
            _uow.BlogPostComments.Update(bc);
            _uow.SaveChanges();
            return blogPostComment;
        }
    }
}