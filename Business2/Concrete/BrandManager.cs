using Business2.Abstract;
using Business2.Constans;
using Business2.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;// Dal a bagimlilik

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;//veri eriism katmaninda bagimliligimiz var ama interface oldugu icin biraz az 
        }

        //[SecuredOperation("admin,brand.add")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResults Add(Brand brand)
        {

            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandAdded);
        }
        //[SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResults Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult< List<Brand>>GetAll()
        {
            //iskodlari
            
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
        }



        [CacheAspect]
        [PerformanceAspect(5)]

        public IDataResult<List<Brand>> GetById(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.BrandId == brandId));
        }



        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]


        public IResults Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
