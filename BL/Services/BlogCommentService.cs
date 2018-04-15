using BL.DTO;
using BL.Factories;
using BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class BlogCommentService : IBlogCommentService
    {
        private readonly DAL.App.Interfaces.IAppUnitOfWork _uow;
        private readonly IBlogCommentFactory _blogCommentFactory;

        public BlogCommentService(DAL.App.Interfaces.IAppUnitOfWork uow, IBlogCommentFactory blogCommentFactory)
        {
            _uow = uow;
            _blogCommentFactory = blogCommentFactory;
        }
            public BlogCommentDTO AddNewBlogComment(BlogCommentDTO newBlogComment)
            {
            var blogComment = _blogCommentFactory.Transform(newBlogComment);
            _uow.BlogComments.Add(blogComment);
            _uow.SaveChanges();
            return newBlogComment;
        }

        public void DeleteBlogComment(int blogCommentId)
        {
            var blogComment = _uow.BlogComments.Find(blogCommentId);
            _uow.BlogComments.Remove(blogComment);
            _uow.SaveChanges();
        }

        public List<BlogCommentDTO> GetAllBlogComments()
            {
            return _uow.BlogComments.All().Select(b => BlogCommentDTO.CreateFromDomain(b)).ToList();
        }

            public BlogCommentDTO GetBlogCommentById(int blogCommentId)
            {
            return BlogCommentDTO.CreateFromDomain(_uow.BlogComments.Find(blogCommentId));
        }

        public BlogCommentDTO UpdateBlogComment(int blogCommentId, BlogCommentDTO blogComment)
        {
            var bc = _blogCommentFactory.Transform(blogComment);
            bc.BlogCommentId = blogCommentId;
            _uow.BlogComments.Update(bc);
            _uow.SaveChanges();
            return blogComment;
        }
    }
    }
