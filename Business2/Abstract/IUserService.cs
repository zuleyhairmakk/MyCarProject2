using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
  public   interface IUserService
    {
        IResults Add(Users user);
        IResults Delete(Users user);
        IResults Update(Users user);
        IResults UpdateSpecificInfos(Users user);
        IDataResult<List<Users>> GetAll();
        IDataResult<Users> GetById(int userId);
        IDataResult<Users> GetByEmail(string email);
        IDataResult<List<OperationClaim>> GetClaims(Users user);
    }
}
