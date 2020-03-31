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
        public Order order { get; set; }
    }

    public class BaseReq
    {
        public virtual List<FilterNode> query { get; set; } = new List<FilterNode>();
    }

    public class PageReq : OrderReq
    {
        //  int pageNum = 1, int pageSize = 20, string field = "id", string order = " desc "
        public int pageNum { get; set; } = 1;
        public int pageSize { get; set; } = 50;
    }

    public class DatetimePointReq : OrderReq
    {
        public DateTime datetimePoint { get; set; }
    }

    public class DatetimePointPageReq : DatetimePointReq
    {

        //  int pageNum = 1, int pageSize = 20, string field = "id", string order = " desc "
        public int pageNum { get; set; } = 1;
        public int pageSize { get; set; } = 50;
    }
}
