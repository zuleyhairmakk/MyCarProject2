using Business2.Abstract;
using Business2.Constans;
using Business2.ValidationRules.FluentValidation;
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
        ICarImagesDal _carImagesDal;
        public CarImageManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResults Add(IFormFile file, CarImages carImage)
        {
           
            var imageCount = _carImagesDal.GetAll(c => c.CarId == carImage.CarId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult("One car must have 5 or less images");
            }

            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImagesDal.Add(carImage);
            return new SuccessResult("Car image added");
        }
        [ValidationAspect(typeof(CarImagesValidator))]
        public IResults Delete(CarImages carImage)
        {
            var image = _carImagesDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            FileHelper.Delete(image.ImagePath);
            _carImagesDal.Delete(carImage);
            return new SuccessResult("Image was deleted successfully");
        }
        [ValidationAspect(typeof(CarImagesValidator))]
        public IDataResult<CarImages> Get(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IDataResult<List<CarImages>> GetImagesByCarId(int id)
        {
            IResults result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImages>>(result.Message);
            }

            return new SuccessDataResult<List<CarImages>>(CheckIfCarImageNull(id).Data);
        }
        [ValidationAspect(typeof(CarImagesValidator))]
        public IResults Update(IFormFile file, CarImages carImage)
        {
            
                var isImage = _carImagesDal.Get(c => c.Id == carImage.Id);
                if (isImage == null)
                {
                    return new ErrorResult("Image not found");
                }

                var updatedFile = FileHelper.Update(file, isImage.ImagePath);
                if (!updatedFile.Success)
                {
                    return new ErrorResult(updatedFile.Message);
                }
                carImage.ImagePath = updatedFile.Message;
                _carImagesDal.Update(carImage);
                return new SuccessResult("Car image updated");
            }




        ///business code
        private IResults CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImagesDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImages>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _carImagesDal.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImages> carimage = new List<CarImages>();
                    carimage.Add(new CarImages { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImages>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImages>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(p => p.CarId == id).ToList());
        }
        private IResults CarImageDelete(CarImages carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
    }

