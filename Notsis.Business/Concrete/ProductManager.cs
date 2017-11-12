using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Notsis.Business.Abstract;
using Notsis.Core.Aspects.Autofac.Logging;
using Notsis.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Notsis.Core.CrossCuttingConcerns.Logging.NLog.Loggers;
using Notsis.DataAccess.Abstract;
using Notsis.Entities.Concrete;

namespace Notsis.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _productDal.Get(filter);
        }

        [LogInterception(typeof(NLogFileLogger))]
        [LogInterception(typeof(Log4NetFileLogger))]
        //[LogInterceptionAspect(typeof(Log4NetFileLogger))]
        //[SecurityOperationInterceptor("Product.Read")]
        //[CacheAspect(typeof(MemoryCacheManager), 1)]
        //[PerformanceInterception(0)]
        //[CacheInterception(typeof(MemoryCacheManager))]     
        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            Thread.Sleep(3000);
            return _productDal.GetList(filter).ToList();
        }
        //[TransactionScopeAspect]
        //[CacheRemoveAspect("*Get*")]
        //[ValidationAspect(typeof(ProductValidation))]
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void DeleteById(int id)
        {
            var product = Get(p => p.ProductId == id);
            _productDal.Delete(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
    }
}
