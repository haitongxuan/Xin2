using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Web.Framework.Model
{
    public class SqlReq
    {
        public string filterStr { get; set; }
    }

    public class OrderSqlReq : SqlReq
    {
        public Order order { get; set; }
    }
    public class GroupOrderReq : OrderReq
    {
        public string groupStr { get; set; } = "";
    }
}
