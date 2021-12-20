using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();
       
        IDataResult<List<Rental>> GetByRentDate(string  rentDate);
        IDataResult<List<Rental>> GetByReturnDate(string returnDate);
        IDataResult<List<Rental>> GetByCarId(int carId);
    }
}
