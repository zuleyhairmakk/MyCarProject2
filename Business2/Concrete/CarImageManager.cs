using Business2.Abstract;
using Business2.BusinessAspects.Autofac;
using Business2.Constans;
using Business2.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business2.Concrete
{
    public class CarImageManager : ICarImagesService
    {
        ICarImagesDal _carImageDal;


        public CarImageManager(ICarImagesDal carimageDal)
        {
            _carImageDal = carimageDal;
        }


        [ValidationAspect(typeof(CarImagesValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]

        public IResults Add(CarImages carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = FileHelper.AddFile(file);

            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }


        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResults Delete(CarImages carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);

            if (image == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            FileHelper.DeleteFile(image.ImagePath);

            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImagesValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]


        public IResults Update(CarImages carImage, IFormFile file)
        {
            var oldImage = _carImageDal.Get(c => c.Id == carImage.Id);

            if (oldImage == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = FileHelper.UpdateFile(file, oldImage.ImagePath);

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }


        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(), Messages.MessageListed);
        }


        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<CarImages> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(ci => ci.Id == carImageId));
        }


        // Business Rules Methods
        private IResults CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(ci => ci.CarId == carId).Count >= 5)
            {
                return new ErrorResult(Messages.CarImageNumberError);
            }
            return new SuccessResult();
        }
    }
    }

