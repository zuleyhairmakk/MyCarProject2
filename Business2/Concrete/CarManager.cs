using Business2.Abstract;
using Business2.Constans;
using Business2.ValidationRules.FluentValidation;
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

        [ValidationAspect(typeof(CarValidator))]// add metodunu car validatora gore dogra,validate islemini car icin yap
        public IResults Add(Car car)
        {
            //businesscode
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult< List<Car>> GetByDailyPrice(int price)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.DailyPrice == price));
        }

        public IDataResult<List<CarDetailDto>>GetCarDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            else { return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails()); }
           
        }
    }
}
