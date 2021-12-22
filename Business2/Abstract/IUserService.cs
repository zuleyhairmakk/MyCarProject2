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
        List<OperationClaim> GetClaims(Users user);
        void Add(Users user);
        Users GetByMail(string email);
    }
}
