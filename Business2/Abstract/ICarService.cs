using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
  public   interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult< List<CarDetailDto>> GetCarDetails();
        IResults Add(Car car );
        IDataResult< List<Car>> GetByDailyPrice(int price );
    }
}
