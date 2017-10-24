using System;
using System.Collections.Generic;
using System.Text;
using Notsis.Core.DataAccess;
using Notsis.Entities.Concrete;

namespace Notsis.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
    }
}
