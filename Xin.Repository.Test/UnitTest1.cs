using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.Repository;
using Xin.Entities;
using Xin.Entities.VirtualEntity;
using System.Collections.Generic;
using Xin.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Xin.Common;
using System.Data.SqlClient;

namespace Xin.Repository.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<ResDepartment>)))
                .Returns(new GenericEntityRepository<ResDepartment>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);

            var uow = provider.CreateUnitOfWork();
            var repository = uow.GetRepository<ResDepartment>();
            var list = repository.GetAll().ToList();
            int id = list[0].Id;
        }
        [TestMethod]
        public void TestContext()
        {
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());
            var query = myContext.Set<ResDepartment>();
            var all = query.First<ResDepartment>(p => p.Id == 1);
        }
        [TestMethod]
        public void TestOne2many()
        {
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<ResUser>)))
                .Returns(new GenericEntityRepository<ResUser>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);

            using (var uow = provider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ResUser>();
                var user = repository.Query(x => x.UserName == "admin" && x.UserPwd == SecretHelper.MD5Encrypt("h111111", "h111111"));
            }
        }
        [TestMethod]
        public void TestMd5()
        {
            string passd = Xin.Common.SecretHelper.MD5Encrypt("h111111", "h111111");
            System.Diagnostics.Debug.WriteLine(passd);
        }

        [TestMethod]
        public void TestProcedure()
        {
            var edate = DateTime.Now;
            var sdate = edate.AddDays(-7);
            var sdatep = new SqlParameter("@Sdate", sdate);
            var edatep = new SqlParameter("@Edate", edate);
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<TotalSale>)))
                .Returns(new GenericEntityRepository<TotalSale>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);

            using (var uow = provider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<TotalSale>();
                var list = repository.FromProcedure("EXECUTE TotalSale_sp @Sdate,@Edate", sdatep, edatep).ToList();
            }
        }
    }
}