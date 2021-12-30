using Business2.Abstract;
using Business2.BusinessAspects.Autofac;
using Business2.Constans;
using Business2.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal cardal)
        {
            _carDal = cardal;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]// add metodunu car validatora gore dogra,validate islemini car icin yap
        [CacheRemoveAspect("ICarService.Get")]
        public IResults Add(Car car)
        {
            //businesscode
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        
        }

       

        [CacheAspect]//key,value //key=cache
        [PerformanceAspect(10)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult< List<Car>> GetByDailyPrice(int price)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.DailyPrice == price));
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<CarDetailDto>>GetCarDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            else { return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails()); }
           
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]//her yeri guncellemesin diye get yazmadim

        public IResults Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.CarUpdated);
        }


        [TransactionScopeAspect]
        public IResults AddTransactionalTest(Car car)
        {
            Add(car);

            if (car.DailyPrice > 5000)
            {
                throw new Exception("");
            }

            Add(car);

            return null;
        }

    }
}
