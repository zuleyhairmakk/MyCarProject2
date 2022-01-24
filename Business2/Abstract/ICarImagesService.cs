using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
 public    interface ICarImagesService
    {


        IResults Add(IFormFile file, CarImages carImage);
        IResults Delete(CarImages carImage);
        IResults Update(IFormFile file, CarImages carImage);

        IDataResult<List<CarImages>> GetAll();
        IDataResult<List<CarImages>> GetByCarId(int carId);
        IDataResult<CarImages> GetByImageId(int imageId);
    }
}
