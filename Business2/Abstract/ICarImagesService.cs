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


        IResults Add(CarImages carImage, IFormFile file);
        IResults Delete(CarImages carImage);
        IResults Update(CarImages carImage, IFormFile file);
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetById(int colorId);
    }
}
