using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
    public interface IBrandService
    {
        IResults Add(Brand brand);
        IResults Delete(Brand brand);
        IResults Update(Brand brand);
        IDataResult< List<Brand>> GetAll();
        IDataResult< List<Brand> >GetById(int brandId);
    }
}
