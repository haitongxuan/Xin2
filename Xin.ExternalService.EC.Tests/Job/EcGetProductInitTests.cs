using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Extensions.Logging;
using Xin.Repository;
using Xin.Entities;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.IO;
using Xin.ExternalService.EC.Response.Model;

namespace Xin.ExternalService.EC.Job.Tests
{
    [TestClass()]
    public class EcGetProductInitTests
    {
        [TestMethod()]
        public async Task JobTest()
        {
            var repository = LogManager.CreateRepository(Common.LogFactory.repositoryName);
            // 指定配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            var logger = new Moq.Mock<ILogger<DataAccess>>();
            var sp = new Moq.Mock<IServiceProvider>();
            var myContext = new Service.Context.XinDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<Service.Context.XinDBContext>());

            sp.Setup((o) => o.GetService(typeof(IEntityContext))).Returns(myContext);

            sp.Setup((o) => o.GetService(typeof(IRepository<ECProduct>)))
                .Returns(new GenericEntityRepository<ECProduct>(logger.Object));
            var provider = new UowProvider(logger.Object, sp.Object);
            try
            {
                EcGetProductInit job = new EcGetProductInit(provider);
                await job.Job();
            }
            catch (Exception ex)
            {

            }
        }
        [TestMethod]
        public void TestDesProduct()
        {
            var setting = new Newtonsoft.Json.JsonSerializerSettings();
            
            string json = "{ \"productSku\": \"BBWCM712\",    \"productSpu\": \"\",    \"productTitle\": \"BBWCM712\",    \"productTitleEn\": \"BBWCM712\",    \"productDeclaredValue\": \"17.00\",    \"pdDeclareCurrencyCode\": \"USD\",    \"productWeight\": \"0.433\",    \"defaultSupplierCode\": \"001\",    \"saleStatus\": \"2\",    \"productLength\": \"0.00\",    \"productWidth\": \"0.00\",    \"productHeight\": \"0.00\",    \"designerId\": \"0\",    \"personOpraterId\": \"564\",    \"personSellerId\": \"0\",    \"personDevelopId\": \"0\",    \"isQc\": \"0\",    \"isExpDate\": \"0\",    \"isGift\": \"0\",    \"warehouseBarcode\": \"\",    \"productAddTime\": \"2020-01-06 19:07:11\",    \"productUpdateTime\": \"2020-02-17 19:17:17\",    \"productNetWeight\": \"0.000\",    \"isCombination\": \"1\",    \"productSizeId\": \"0\",    \"productColorId\": \"0\",    \"puName\": \"\",    \"defaultWarehouseId\": \"0\",    \"eanCode\": \"\",    \"userOrganizationId\": \"0\",    \"prl_id\": \"0\",    \"oprationType\": \"2\",    \"ppnReleaseDate\": \"\",    \"productStatus\": \"1\",    \"procutCategoryCode1\": \"6\",    \"procutCategoryName1\": \"假发\",    \"procutCategoryCode2\": \"55\",    \"procutCategoryName2\": \"组合商品\",    \"sp_unit_price\": \"243.5800\",    \"currency_code\": \"USD\",    \"productCombination\": [      {        \"pcrFnsku\": \"\",        \"pcrFbaAsin\": \"\",        \"warehouseId\": \"0\",        \"pcrAddTime\": \"2020-01-07 13:35:59\",        \"pcrUpdateTime\": \"\",        \"subProducts\": [          {            \"pcrProductSku\": \"B-HW-N-BW-18\",            \"pcrQty\": \"2\"          },          {            \"pcrProductSku\": \"B-HW-N-BW-20\",            \"pcrQty\": \"2\"          },          {            \"pcrProductSku\": \"B-HCM-N-BW-12\",            \"pcrQty\": \"1\"          }        ]      }    ],    \"productBox\": [],    \"property\": [],    \"productCustomCategory\": [],    \"productImages\": \"\"  }";
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<EC_Product>(json);
        }
    }
}