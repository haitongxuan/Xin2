using System;
using System.Collections.Generic;
using System.Text;
using Xin.Common.CustomAttribute;

namespace Xin.Entities.VirtualEntity
{
    public class ECHeadTripLine
    {
        /// <summary>
        /// 行号
        /// </summary>
        [Excel(Header = "行号")]
        public long RowNumber { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Excel(Header = "订单号")]
        public string Ordercode { get; set; }
        /// <summary>
        /// 服务商单号
        /// </summary>
        [Excel(Header = "服务商单号")]
        public string ReferenceNo { get; set; }
        /// <summary>
        /// 制单日期
        /// </summary>
        [Excel(Header = "制单日期")]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 预计到货日期
        /// </summary>
        [Excel(Header = "预计到货日期")]
        public DateTime ExpectedDate { get; set; }
        /// <summary>
        /// 外部SKU
        /// </summary>
        [Excel(Header = "外部SKU")]
        public string OutSku { get; set; }
        /// <summary>
        /// 内部子SKU
        /// </summary>
        [Excel(Header = "内部子SKU")]
        public string ItemSku { get; set; }
        /// <summary>
        /// 店铺
        /// </summary>
        [Excel(Header = "店铺")]
        public string StoreName { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        [Excel(Header = "公司")]
        public string CompanyName { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        [Excel(Header = "币种")]
        public string Currery { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Excel(Header = "数量")]
        public int Qty { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [Excel(Header = "单价")]
        public decimal Price { get; set; }
        /// <summary>
        /// 总成本
        /// </summary>
        [Excel(Header = "总成本")]
        public decimal Cost { get; set; }
        /// <summary>
        /// 中转仓
        /// </summary>
        [Excel(Header = "中转仓")]
        public string Warehouse { get; set; }
        /// <summary>
        /// 目的仓
        /// </summary>
        [Excel(Header = "目的仓")]
        public string ToWarehouse { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Excel(Header = "备注")]
        public string Remark { get; set; }
    }
}
