using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Web.Framework.Model
{
    public class BaseReq
    {
        public Order order { get; set; } = new Order() { columnName = "Id", reverse = false };
        public virtual List<FilterNode> query { get; set; } = new List<FilterNode>();
        public string[] navPropertyPaths { get; set; }
    }
}
