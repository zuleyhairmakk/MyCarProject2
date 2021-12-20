using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
    public interface IColorService
    {
      IDataResult<List<Color> >GetAll();
        IDataResult< List<Color>> GetById(int colorId);
        IResults Add(Color color);
    }
}
