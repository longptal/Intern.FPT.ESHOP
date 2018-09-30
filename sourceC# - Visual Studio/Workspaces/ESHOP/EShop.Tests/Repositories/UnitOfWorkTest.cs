using Microsoft.VisualStudio.TestTools.UnitTesting;
using EShop.Models;
using EShop.MAdmin;
using EShop.MAdmin.MCategory;

namespace EShop.Tests.Repositories
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void Init()
        {
            UnitOfWork UnitOfWork = new UnitOfWork();
        }
    }
}
