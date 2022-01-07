using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
  public   interface ICommentService
    {

        IResults Add(Comment comment);
        IResults Delete(Comment comment);
    }
}
