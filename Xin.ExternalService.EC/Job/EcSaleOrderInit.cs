using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Xin.Common;
using Xin.Entities;
using Xin.Repository;
using Xin.ExternalService.EC.Reqeust;
using Xin.ExternalService.EC.Response;
using Xin.ExternalService.EC.Response.Model;
using Xin.ExternalService.EC.Reqeust.Model;

namespace Xin.ExternalService.EC.Job
{
    public class EcSaleOrderInit : EcBaseJob
    {
        private readonly LogHelper log;
        private readonly IUowProvider _uowProvider;
        public EcSaleOrderInit(IUowProvider uowProvider)
        {
            log = LogFactory.GetLogger(LogType.QuartzLog);
            _uowProvider = uowProvider;
        }
        public override async Task Execute(IJobExecutionContext context)
        {
            await Job();
        }

        public override async Task Job(DateTime? datetime = null)
        {
            var models = new List<ECSalesOrder>();
            var reqModel = new EBGetOrderListReqModel();
            reqModel.PageSize = 500;
            reqModel.GetDetail = IsOrNotEnum.Yes;
            reqModel.GetAddress = IsOrNotEnum.Yes;
            bool finish = true;
            int pageIndex = 1;
            int submitPageQty = 10;

            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repository = uow.GetRepository<ECSalesOrder>();
                var addRepository = uow.GetRepository<ECSalesOrderAddress>();
                try
                {
                    await repository.DeleteAll();
                    await addRepository.DeleteAll();
                    await uow.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    log.Error($"初始化产品信息,删除产品信息异常:{ex.Message}");
                    throw ex;
                }
                while (finish)
                {
                    reqModel.Page = pageIndex;
                    Reqeust.EBGetOrderListRequest req = new EBGetOrderListRequest(login.Username, login.Password, reqModel);
                    Response.EBGetOrderListResponse resp = null;
                    try
                    {
                        resp = await req.Request();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"初始化产品信息,获取数据错误:{ex.Message}");
                        throw ex;
                    }
                    if (resp.Body.Count == reqModel.PageSize)
                    {
                        foreach (var i in resp.Body)
                        {
                            try
                            {
                                var m = Mapper<EC_SalesOrder, ECSalesOrder>.Map(i);
                                models.Add(m);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        if (pageIndex % submitPageQty == 0)
                        {
                            #region
                            //string sql = "";
                            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(models);
                            #endregion
                            try
                            {
                                #region
                                //foreach (var mo in models)
                                //{
                                //    sql += $"INSERT INTO [dbo].[EC_SalesOrderAddress]([ShippingAddressId],[Name],[CompanyName],[CountryCode],[CountryName],[CityName],[PostalCode],[Line1],[Line2],[Line3],[District],[State],[Doorplate],[Phone],[CreatedDate],[UpdateDate])     VALUES(\'{mo.SalesOrderAddress.ShippingAddressId}\',\'{mo.SalesOrderAddress.Name.Replace("'", "''")}\',\'{mo.SalesOrderAddress.CompanyName.Replace("'", "''")}\',\'{mo.SalesOrderAddress.CountryCode.Replace("'", "''")}\',\'{mo.SalesOrderAddress.CountryName.Replace("'", "''")}\',\'{mo.SalesOrderAddress.CityName.Replace("'", "''")}\',\'{mo.SalesOrderAddress.PostalCode.Replace("'", "''")}\',\'{mo.SalesOrderAddress.Line1.Replace("'", "''")}\',\'{mo.SalesOrderAddress.Line2.Replace("'", "''")}\',\'{mo.SalesOrderAddress.Line3.Replace("'", "''")}\',\'{mo.SalesOrderAddress.District.Replace("'", "''")}\',\'{mo.SalesOrderAddress.State.Replace("'", "''")}\',\'{mo.SalesOrderAddress.Doorplate.Replace("'", "''")}\',\'{mo.SalesOrderAddress.Phone.Replace("'", "''")}\',\'{mo.SalesOrderAddress.CreatedDate}\',\'{mo.SalesOrderAddress.UpdateDate}\');\r\n";
                                //    sql += $"INSERT INTO [dbo].[EC_SalesOrder]([OrderId],[Plateform],[OrderType],[Status],[ProcessAgain],[RefNo],[SaleOrderCode],[SysOrderCode]," +
                                //        $"[WarehouseOrderCode],[CompanyCode],[UserAccount],[PlatformUserName],[ShippingMethod],[ShippingMethodNo],[ShippingMethodPlatform],[WarehouseId]," +
                                //        $"[WarehouseCode],[CreatedDate],[UpdateDate],[DatePaidPlatform],[PlatformShipStatus],[PlatformShipTime],[DateWarehouseShipping],[DateLatestShip]," +
                                //        $"[Currency],[Amountpaid],[Subtotal],[ShipFee],[PlatformFeeTotal],[FinalvaluefeeTotal],[OtherFee],[CostShipFee],[BuyerId],[BuyerName],[BuyerMail]," +
                                //        $"[Site],[CountryCode],[ProductCount],[OrderWeight],[OrderDesc],[PaypalTransactionId],[PaymentMethod],[AbnormalType],[AbnormalReason],[ShippingAddressId],[OriginalOrderId]," +
                                //        $"[SyncCode])     VALUES(\'{mo.OrderId}\',\'{mo.Plateform}\',\'{mo.OrderType}\',\'{mo.Status}\',\'{mo.ProcessAgain}\',\'{mo.RefNo}\',\'{mo.SaleOrderCode}\',\'{mo.SysOrderCode}\',\'{mo.WarehouseOrderCode}\',\'{mo.CompanyCode}\',\'{mo.UserAccount}\',\'{mo.PlatformUserName}\',\'{mo.ShippingMethod}\',\'{mo.ShippingMethodNo}\',\'{mo.ShippingMethodPlatform}\',\'{mo.WarehouseId}\',\'{mo.WarehouseCode}\',\'{mo.CreatedDate}\',\'{mo.UpdateDate}\',\'{mo.DatePaidPlatform}\',\'{mo.PlatformShipStatus}\',\'{mo.PlatformShipTime}\'," +
                                //        $"\'{mo.DateWarehouseShipping}\',\'{mo.DateLatestShip}\',\'{mo.Currency.Replace("'", "''")}\',\'{mo.Amountpaid}\',\'{mo.Subtotal}\',\'{mo.ShipFee}\',\'{mo.PlatformFeeTotal}\',\'{mo.FinalvaluefeeTotal}\',\'{mo.OtherFee}\',\'{mo.CostShipFee}\',\'{mo.BuyerId}\',\'{mo.BuyerName.Replace("'", "''")}\',\'{mo.BuyerMail}\',\'{mo.Site}\',\'{mo.CountryCode}\',\'{mo.ProductCount}\',\'{mo.OrderWeight}\',\'{mo.OrderDesc.Replace("'", "''")}\',\'{mo.PaypalTransactionId}\',\'{mo.PaymentMethod}\',\'{mo.AbnormalType}\',\'{mo.AbnormalReason.Replace("'", "''")}\',\'{mo.SalesOrderAddress.ShippingAddressId}\',null,\'{mo.SyncCode}\');\r\n";
                                //    foreach (var detail in mo.OrderDetails)
                                //    {
                                //        sql += $"INSERT INTO [dbo].[EC_SalesOrderDetail]([OpId],[OrderId],[ProductSku],[Sku],[WarehouseSku],[UnitPrice],[Qty],[ProductTitle],[Pic],[OpSite],[ProductUrl],[RefItemId],[OpRefItemLocation],[UnitFinalValueFee],[TransactionPrice],[OperTime])     VALUES(\'{detail.OpId}\',\'{mo.OrderId}\',\'{detail.ProductSku}\',\'{detail.Sku}\',\'{detail.WarehouseSku}\',\'{detail.UnitPrice}\',\'{detail.Qty}\',\'{detail.ProductTitle.Replace("'", "''")}\',\'{detail.Pic}\',\'{detail.OpSite}\',\'{detail.ProductUrl}\',\'{detail.RefItemId}\',\'{detail.OpRefItemLocation}\',\'{detail.UnitFinalValueFee}\',\'{detail.TransactionPrice}\',\'{detail.OperTime}\');\r\n";
                                //    }
                                //}
                                //Console.Write(sql);
                                #endregion
                                await repository.BulkInsertAsync(models, x => x.IncludeGraph = true);
                                uow.BulkSaveChanges();
                                models.Clear();
                            }
                            catch (Exception ex)
                            {
                                log.Error($"初始化产品信息,批量导入产品异常:第{pageIndex}页,{ex.Message}");
                                throw ex;
                            }
                        }
                        pageIndex++;
                    }
                    else
                    {
                        try
                        {
                            foreach (var i in resp.Body)
                            {
                                try
                                {
                                    var m = Mapper<EC_SalesOrder, ECSalesOrder>.Map(i);
                                    models.Add(m);
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                            await repository.BulkInsertAsync(models, x => x.IncludeGraph = true);
                            uow.BulkSaveChanges();
                            models.Clear();
                        }
                        catch (Exception ex)
                        {
                            log.Error($"初始化产品信息,批量导入产品异常:第{pageIndex}页,{ex.Message}");
                            throw ex;
                        }
                        finish = false;
                    }
                }

            }
        }
    }
}
