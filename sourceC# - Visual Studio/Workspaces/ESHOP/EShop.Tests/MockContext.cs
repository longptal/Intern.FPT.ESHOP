using EShop.Models;
using Newtonsoft.Json;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EShop.Tests
{
    public class MockContext : EShopContext
    {
        protected IDocumentStore   DocumentStore;
        protected IDocumentSession DocumentSession;
        private   DbSet<Carrier>   _carriers;

        public MockContext()
        {
            DocumentStore = new DocumentStore()
            {
                Urls     = new[] {"http://10.1.11.171:88"},
                Database = "EShop"
            }.Initialize();
            DocumentSession = DocumentStore.OpenSession();
        }

        ~MockContext()
        {
            DocumentSession.Dispose();
            DocumentStore.Dispose();
        }

        public override DbSet<Carrier> Carriers => _carriers ?? (_carriers = new MockDbSet<Carrier>(CarriersData).Object);

        public IQueryable<Carrier> CarriersData
        {
            get
            {
                var    List = DocumentSession.Query<dynamic>(collectionName: "Carriers").ToList();
                string temp = JsonConvert.SerializeObject(List);
                return JsonConvert.DeserializeObject<List<Carrier>>(temp).AsQueryable();
            }
        }

        class MockDbSet<T> : Mock<DbSet<T>> where T : class
        {
            public MockDbSet(IQueryable<T> data)
            {
                this.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
                this.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
                this.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
                this.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            }
        }
    }
}