using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
  public   class EfBrandDal : EfEntityRepositoryBase<Brand, CarContext>, IBrandDal
    {
    
    }
}
