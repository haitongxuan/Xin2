using System;
using System.Collections.Generic;
using System.Text;
using Xin.Common.CustomAttribute;

namespace Xin.Entities.VirtualEntity
{
    public class SkuSaleQueryReport
    {
        [Excel(Header = "主键")]

        public int id { get; set; }
        [Excel(Header = "店铺")]

        public string storeName { get; set; }
        [Excel(Header = "商品")]

        public string sku { get; set; }
        [Excel(Header = "商品数量")]

        public int? qty { get; set; }
    }
}
