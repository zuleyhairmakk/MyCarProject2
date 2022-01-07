using Business2.Abstract;
using Business2.Constans;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Concrete
{
    public class CommentManager : ICommentService
    {


        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }


      
        [CacheRemoveAspect("ICommentService.Get")]
        public IResults Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }


        [CacheRemoveAspect("ICommentService.Get")]
        public IResults Delete(Comment comment)
        {
            _commentDal.Delete(comment);

            return new SuccessResult(Messages.CommentDeleted);
        }
    }
}
