using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.Abstract
{
    public interface IColorService
    {
        IResults Add(Color color);
        IResults Delete(Color color);
        IResults Update(Color color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int colorId);
    }
}
