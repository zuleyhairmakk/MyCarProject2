using Business2.Abstract;
using Business2.Constans;
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

        public IDataResult< List<Brand>>GetAll()
        {
            //iskodlari
            
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
        }

        public IDataResult<List<Brand>> GetById(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.BrandId == brandId));
        }
    }
}
