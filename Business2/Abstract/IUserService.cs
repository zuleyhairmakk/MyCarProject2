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
        IDataResult<List<Users>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResults Add(Users user);
        IDataResult<List<Users>> GetByFirstName(string name);
    }
}
