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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResults Add(Color color)
        {

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }


        [CacheRemoveAspect("IColorService.Get")]
        public IResults Delete(Color color)
        {
            _colorDal.Delete(color);

            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Color>> GetAll()
        {
           return  new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed);
        }

       

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResults Update(Color color)
        {
            _colorDal.Update(color);

            return new SuccessResult(Messages.ColorUpdated);
        }


        [CacheAspect]
        [PerformanceAspect(10)]
        public   IDataResult<Color>GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }
    }
}
