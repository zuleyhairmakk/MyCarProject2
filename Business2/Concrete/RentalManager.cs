using Business2.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IDataResult<List<Rental>> GetAll()
        {
         return new    SuccessDataResult<List<Rental>>();
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p=>p.CarId== carId));
        }

       

        public IDataResult<List<Rental>> GetByRentDate(string rentDate)
        {
            return  new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.RentDate== rentDate));
        }

        public IDataResult<List<Rental>> GetByReturnDate(string returnDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.ReturnDate == returnDate));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>();
        }
    }
}
