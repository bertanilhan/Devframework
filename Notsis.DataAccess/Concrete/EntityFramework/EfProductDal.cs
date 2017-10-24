using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Notsis.Core.DataAccess.EntityFramework;
using Notsis.DataAccess.Abstract;
using Notsis.Entities.Concrete;

namespace Notsis.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {

    }
}
