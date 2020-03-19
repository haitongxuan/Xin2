using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Xin.Repository;
using Xin.Entities.VirtualEntity;
using System.Linq;

namespace Xin.Service.Tests
{
    [TestClass()]
    public class SingleSalesAnlysisReporitoryTests
    {
        [TestMethod()]
        public void GetListTest()
        {
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<SingleSalesAnalysis>)))
                .Returns(new GenericEntityRepository<SingleSalesAnalysis>(logger.Object));
            sp.Setup((o) => o.GetService(typeof(ISingleSalesAnlysisRepository)))
                .Returns(new SingleSalesAnlysisRepository(myContext));
            var provider = new UowProvider(logger.Object, sp.Object);
            using (var uow = provider.CreateUnitOfWork())
            {
                var repository = uow.GetCustomRepository<ISingleSalesAnlysisRepository>();
                var list = repository.GetPage(DateTime.Now,10,50);
            }
        }
    }
}