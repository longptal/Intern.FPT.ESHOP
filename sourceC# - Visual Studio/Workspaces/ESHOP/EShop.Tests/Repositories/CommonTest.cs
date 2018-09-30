using EShop.MAdmin;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Tests.Repositories
{
    public class CommonTest
    {
        protected IUnitOfWork UnitOfWork;
        protected MockContext MockContext;

        public CommonTest()
        {
            MockContext = new MockContext();
            UnitOfWork = new UnitOfWork(MockContext);
        }
        ~CommonTest() 
        {
            UnitOfWork.Dispose();
        }
    }
}
