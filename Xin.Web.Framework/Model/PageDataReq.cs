using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xin.Web.Framework.Model;

namespace Xin.Web.Framework.Model
{
    public class NavigateOrderPageDataReq : NavigateOrderReq
    {
        //  int pageNum = 1, int pageSize = 20, string field = "id", string order = " desc "
        public int pageNum { get; set; } = 1;
        public int pageSize { get; set; } = 20;
    }

    public class OrderPageDataReq : OrderReq
    {

        //  int pageNum = 1, int pageSize = 20, string field = "id", string order = " desc "
        public int pageNum { get; set; } = 1;
        public int pageSize { get; set; } = 20;
    }
}
