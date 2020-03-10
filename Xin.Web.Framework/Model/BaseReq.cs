using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Web.Framework.Model
{
    public class NavigateOrderReq : OrderReq
    {
        public string[] navPropertyPaths { get; set; } = null;
    }


    public class OrderReq : BaseReq
    {
        public Order order { get; set; } = new Order() { columnName = "Id", reverse = false };
    }

    public class BaseReq
    {
        public virtual List<FilterNode> query { get; set; } = new List<FilterNode>();
    }

}
