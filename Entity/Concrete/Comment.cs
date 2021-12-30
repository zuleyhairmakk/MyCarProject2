using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
   public  class Comment:IEntity
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
    }
}
