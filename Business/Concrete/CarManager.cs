
using DataAccess.Abstract;
using Business.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Concrete
{
    public class CarManager :ICarService
    {
      ICarDal _carDal;

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
