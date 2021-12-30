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
        IResults Add(Rental rental);
        IResults Delete(Rental rental);
        IResults Update(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<Rental> GetIdByRentalInfos(int carId, int customerId, DateTime rentDate, DateTime returnDate);
        IDataResult<List<CarDetailDto>> GetCarDetails();
       // IDataResult<List<RentalDetailDto>> GetRentalDetails();;
    }
}
