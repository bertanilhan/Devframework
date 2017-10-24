using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notsis.DataAccess.Concrete.EntityFramework;

namespace Notsis.DataAccess.Tests
{
    [TestClass]
    public class ProductDalTests
    {
        [TestMethod]
        public void ShouldMustComeAllProducts()
        {
            var productDal = new EfProductDal();
            var products = productDal.GetList();

            Assert.AreEqual(products.Count,77);
        }
    }
}
