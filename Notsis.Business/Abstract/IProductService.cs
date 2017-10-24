﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Notsis.Core.Business;
using Notsis.Entities.Concrete;

namespace Notsis.Business.Abstract
{
    public interface IProductService:IServiceRepository<Product>
    {
        Product Get(Expression<Func<Product,bool>> filter);
        List<Product> GetList(Expression<Func<Product, bool>> filter = null);
        void Add(Product product);
        void Update(Product product);
        void DeleteById(int id);
        void Delete(Product product);

    }
}
