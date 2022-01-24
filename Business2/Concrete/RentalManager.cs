using Business2.Abstract;
using Business2.BusinessAspects.Autofac;
using Business2.Constans;
using Business2.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IResults Add(Rental rental)
        {
            var result = BusinessRules.Run(CarAvailabilityCheck(rental),
                                          FindeksScoreAvailabilityCheck(rental));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }



        [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResults Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.MessageListed);
        }


        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.id == rentalId));
        }


        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<Rental> GetIdByRentalInfos(int carId, int customerId, DateTime rentDate, DateTime returnDate)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId
                                                               && r.CustomerId == customerId
                                                               && r.RentDate == rentDate
                                                               && r.ReturnDate == returnDate));
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResults Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult(Messages.RentalUpdated);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>();
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.MessageListed);
        }





        private IResults FindeksScoreAvailabilityCheck(Rental rental)
        {
            var result = _rentalDal.GetFindeksScores(rental.CarId, rental.CustomerId);

            if (result.CarMinFindeksScore <= result.CustomerFindeksScore)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.FindeksScoreIsNotEnough);
            }
        }
        // Business Rules Methods
        private IResults CarAvailabilityCheck(Rental rental)
        {
            var overlappingDateList = _rentalDal.GetRentalDetails(r => r.CarId == rental.CarId
                                                                  && r.RentDate < rental.ReturnDate
                                                                  && r.ReturnDate > rental.RentDate);

            if (overlappingDateList.Count() == 0)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.CarIsAlreadyRented);
            }
        }

    }
}
