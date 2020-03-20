using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xin.ExternalService.EC.WMS.Request;
using System;
using System.Collections.Generic;
using System.Text;
using Xin.ExternalService.EC.WMS.Request.Model;
using System.Text.RegularExpressions;

namespace Xin.ExternalService.EC.WMS.Request.Tests
{
    [TestClass()]
    public class QueryFbaOrderRequestTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task RequestTestAsync()
        {
//            string str = @"public class TransitBox{
//public int? Id { get; set; }
//public int? WarehouseId { get; set; }
//public int? BoxId { get; set; }
//public string BoxCode { get; set; }
//public string FbaCode { get; set; }
//public decimal? Length { get; set; }
//public decimal? Width { get; set; }
//public decimal? Height { get; set; }
//public decimal? Weight { get; set; }
//public int? ProQty { get; set; }
//public int? MeasureUserId { get; set; }
//public DateTime? MeasureTime { get; set; }
//public DateTime? ArriveTime { get; set; }
//public DateTime? OutTime { get; set; }
//public int? ReceiptStatus { get; set; }
//public int? MeasureStatus { get; set; }
//public int? ExceptionStatus { get; set; }
//public int? ExceptionConfirm { get; set; }
//public string ExceptionInfo { get; set; }
//public DateTime? UpdateTime { get; set; }
//}";
//            str = Regex.Replace(str, @"[\r\n]", "");
//            string sqlhead = "EC_";
//            string sqlbody = "";
//            for (int i = 0; i < str.Length; i++)

//                if (str[i] == 'p' && str[i + 1] == 'u' && str[i + 2] == 'b' && str[i + 3] == 'l' && str[i + 4] == 'i' && str[i + 5] == 'c')
//                {
//                    if (i == 0)
//                    {
//                        i += 13;
//                        for (; ; )
//                        {
//                            if (str[i] == '{') break;
//                            sqlhead += str[i];
//                            i++;
//                        }
//                    }
//                    else
//                    {
//                        string type = "";
//                        string sqltype = "";
//                        string sqlname = "";
//                        i += 7;
//                        for (; ; )
//                        {
//                            if (str[i] == ' ') break;
//                            type += str[i];
//                            i++;
//                        }
//                        switch (type)
//                        {
//                            case "string":
//                                sqltype = " nvarchar(255),\r\n";
//                                break;
//                            case "bool":
//                                sqltype = " nvarchar(255),\r\n";
//                                break;
//                            case "DateTime":
//                                sqltype = " datetime,\r\n";
//                                break;
//                            case "decimal":
//                                sqltype = " decimal(18, 0),\r\n";
//                                break;
//                            case "int":
//                                sqltype = " int,\r\n";
//                                break;
//                            default:
//                                sqltype = " " + type + ",\r\n";
//                                break;
//                        }
//                        i++;
//                        for (; ; )
//                        {
//                            if (str[i] == ' ') break;
//                            sqlname += str[i];
//                            i++;
//                        }
//                        sqlbody += sqlname + sqltype;
//                        i += 13;
//                    }
//                }

//            string sql = "create table " + sqlhead + "(\r" + sqlbody + ")";
//            Console.WriteLine(sql);

            try
            {
                QueryFbaOrderRequestModel model = new QueryFbaOrderRequestModel();
                model.FbaCode = "FZ-A007-200119-0001";
                QueryFbaOrderRequest req = new QueryFbaOrderRequest("7417441d04ea6267a57cbb6cdced5552",
                    "726fb5fbe5b258d33e32aba78df42e83",
                    model);
                var res = await req.Request();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}