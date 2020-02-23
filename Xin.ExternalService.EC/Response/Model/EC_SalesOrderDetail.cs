//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//	   生成时间 2020-02-05 09:46:35
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失
//     作者：Justable
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace Xin.ExternalService.EC.Response.Model
{
    public partial class EC_SalesOrderDetail
    {
        /// <summary>
        /// 原系统主键
        /// </summary>

        public string OpId { get; set; }
        /// <summary>
        /// 易仓订单主键
        /// </summary>

        public string OrderId { get; set; }
        /// <summary>
        /// 销售sku
        /// </summary>

        public string ProductSku { get; set; }
        /// <summary>
        /// 仓库sku对应关系 ：sku数量费用比例
        /// </summary>

        public string Sku { get; set; }
        /// <summary>
        /// 仓库sku
        /// </summary>

        public string WarehouseSku { get; set; }
        /// <summary>
        /// 单价
        /// </summary>

        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>

        public int? Qty { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>

        public string ProductTitle { get; set; }
        /// <summary>
        /// 产品封面图片
        /// </summary>

        public string Pic { get; set; }
        /// <summary>
        /// 产品站点
        /// </summary>

        public string OpSite { get; set; }
        /// <summary>
        /// 产品url
        /// </summary>

        public string ProductUrl { get; set; }
        /// <summary>
        /// 跟踪明细id，产品明细唯一标识
        /// </summary>

        public string RefItemId { get; set; }
        /// <summary>
        /// ebay Item产地,Amazon商品ASIN值
        /// </summary>

        public string OpRefItemLocation { get; set; }
        /// <summary>
        /// 单个交易费
        /// </summary>

        public decimal? UnitFinalValueFee { get; set; }
        /// <summary>
        /// 单个手续费
        /// </summary>

        public decimal? TransactionPrice { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>

        public DateTime? OperTime { get; set; }

    }
}

