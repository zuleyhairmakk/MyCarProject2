using Business2.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
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
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
    }
}
