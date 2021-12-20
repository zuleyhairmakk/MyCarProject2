using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
           using (CarContext context = new CarContext())
            {
                var results = from c in context.Cars

                              join b in context.Brands
                              on c.BrandId equals b.BrandId
                              select new CarDetailDto {CarId=c.CarId,CarName=c.CarName,BrandId=b.BrandId,BrandName=b.BrandName };
                return results.ToList();
            }
        }
    }
}
