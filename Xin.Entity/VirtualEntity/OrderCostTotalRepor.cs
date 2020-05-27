using System;
using System.Collections.Generic;
using System.Text;
using Xin.Common.CustomAttribute;

namespace Xin.Entities.VirtualEntity
{
    /// <summary>
    /// 财务订单合计报表
    /// </summary>
    public class OrderCostTotalReport
    {
        [Excel(Header ="主键")]
        public Guid id { get; set; }
        /// <summary>
        /// 平台
        /// </summary>
        [Excel(Header = "平台")]
        public string plateform { get; set; }
        /// <summary>
        /// 店铺
        /// </summary>
        [Excel(Header = "店铺")]
        public string storeName { get; set; }
        /// <summary>
        /// 货币类型
        /// </summary>
        [Excel(Header = "货币类型")]
        public string currency { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        [Excel(Header = "订单数量")]
        public int? orderQty { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        [Excel(Header = "商品数量")]
        public int? productQty { get; set; }
        /// <summary>
        /// 订单总运费
        /// </summary>
        [Excel(Header = "订单总运费")]

        public decimal? shipFee { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        [Excel(Header = "订单总金额")]
        public decimal? total { get; set; }
        /// <summary>
        /// 订单总成本
        /// </summary>
        [Excel(Header = "订单总成本")]
        public decimal? cost { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        [Excel(Header = "订单状态")]
        public int status { get; set; }

        /// <summary>
        /// 发货仓库
        /// </summary>
        [Excel(Header = "发货仓库")]
        public string warehouseCode { get; set; }
        /// <summary>
        /// 订单毛利率
        /// </summary>
        [Excel(Header = "订单毛利率")]
        public string grossmargin { get; set; }
    }
}
