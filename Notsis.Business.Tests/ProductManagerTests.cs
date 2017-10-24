using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Notsis.Business.Concrete;
using Notsis.DataAccess.Abstract;
using Notsis.DataAccess.Concrete.EntityFramework;
using Notsis.Entities.Concrete;

namespace Notsis.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void FluentValidationCheck()
        {
            var productDalMock = new Mock<IProductDal>();

            var productManager = new ProductManager(productDalMock.Object);

            productManager.Add(new Product());
        }
    }
}
