using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
  public   interface ICustomerDal:IEntityRepository<Customer>
    {

        UserWhoIsCustomerDto GetCustomerIdOfUser(string email);

    }
}
