﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/6/3 15:50:40
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;

namespace Xin.Entities
{
    public partial class ECSalesOrder {

        public ECSalesOrder()
        {
            this.OrderDetails = new List<ECSalesOrderDetail>();
            this.BnsSendDeliverdToEcs = new List<BnsSendDeliverdToEc>();
            OnCreated();
        }

        /// <summary>
        /// 订单ID
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string OrderId
        {
            get;
            set;
        }

        /// <summary>
        /// 平台代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(1500)]
        public virtual string Plateform
        {
            get;
            set;
        }

        /// <summary>
        /// 订单类型，sale：正常销售订单，resend：重发订单，line：线下订单
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string OrderType
        {
            get;
            set;
        }

        /// <summary>
        /// 订单状态
        /// </summary>
        public virtual int? Status
        {
            get;
            set;
        }

        /// <summary>
        /// 待发货下的处理状态，1:已处理,2:未处理，3：处理异常
        /// </summary>
        public virtual int? ProcessAgain
        {
            get;
            set;
        }

        /// <summary>
        /// 参考单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string RefNo
        {
            get;
            set;
        }

        /// <summary>
        /// 销售单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string SaleOrderCode
        {
            get;
            set;
        }

        /// <summary>
        /// 系统单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string SysOrderCode
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库单号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string WarehouseOrderCode
        {
            get;
            set;
        }

        /// <summary>
        /// 公司代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string CompanyCode
        {
            get;
            set;
        }

        /// <summary>
        /// 账号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(1500)]
        public virtual string UserAccount
        {
            get;
            set;
        }

        /// <summary>
        /// 账号别名
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(1500)]
        public virtual string PlatformUserName
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OldShippingMethod
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string OldShippingMethodNo
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库运输方式代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ShippingMethod
        {
            get;
            set;
        }

        /// <summary>
        /// 跟踪号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ShippingMethodNo
        {
            get;
            set;
        }

        /// <summary>
        /// 平台运输方式代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ShippingMethodPlatform
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库id
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(1500)]
        public virtual string WarehouseId
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string WarehouseCode
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual System.DateTime? CreatedDate
        {
            get;
            set;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual System.DateTime? UpdateDate
        {
            get;
            set;
        }

        /// <summary>
        /// 平台付款时间
        /// </summary>
        public virtual System.DateTime? DatePaidPlatform
        {
            get;
            set;
        }

        /// <summary>
        /// 平台发货状态，0：未发货，1：已发货
        /// </summary>
        public virtual int? PlatformShipStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 平台发货时间
        /// </summary>
        public virtual System.DateTime? PlatformShipTime
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库发货时间
        /// </summary>
        public virtual System.DateTime? DateWarehouseShipping
        {
            get;
            set;
        }

        /// <summary>
        /// 最晚发货时间
        /// </summary>
        public virtual System.DateTime? DateLatestShip
        {
            get;
            set;
        }

        /// <summary>
        /// 币种
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(1500)]
        public virtual string Currency
        {
            get;
            set;
        }

        /// <summary>
        /// 总金额
        /// </summary>
        public virtual decimal? Amountpaid
        {
            get;
            set;
        }

        /// <summary>
        /// 销售额
        /// </summary>
        public virtual decimal? Subtotal
        {
            get;
            set;
        }

        /// <summary>
        /// 运费
        /// </summary>
        public virtual decimal? ShipFee
        {
            get;
            set;
        }

        /// <summary>
        /// 总手续费
        /// </summary>
        public virtual decimal? PlatformFeeTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 总交易费
        /// </summary>
        public virtual decimal? FinalvaluefeeTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 其他费用
        /// </summary>
        public virtual decimal? OtherFee
        {
            get;
            set;
        }

        /// <summary>
        /// 试算运费
        /// </summary>
        public virtual decimal? CostShipFee
        {
            get;
            set;
        }

        /// <summary>
        /// 买家ID
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string BuyerId
        {
            get;
            set;
        }

        /// <summary>
        /// 买家名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string BuyerName
        {
            get;
            set;
        }

        /// <summary>
        /// 买家邮箱
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string BuyerMail
        {
            get;
            set;
        }

        /// <summary>
        /// 订单站点
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string Site
        {
            get;
            set;
        }

        /// <summary>
        /// 收件人国家二字码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string CountryCode
        {
            get;
            set;
        }

        /// <summary>
        /// 订单出库数量
        /// </summary>
        public virtual int? ProductCount
        {
            get;
            set;
        }

        /// <summary>
        /// 订单重量
        /// </summary>
        public virtual decimal? OrderWeight
        {
            get;
            set;
        }

        /// <summary>
        /// 买家留言
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string OrderDesc
        {
            get;
            set;
        }

        /// <summary>
        /// paypal交易号
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PaypalTransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// 付款方式/支付方式（仅Shopee平台可用）
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(25)]
        public virtual string PaymentMethod
        {
            get;
            set;
        }

        /// <summary>
        /// 异常类型：1:换地址,2:退货取消,3:换SKU,4:其他，5：同步服务商失败，6:断货,7：SKU未找到, 11:无门牌号, 12:计费失败, 21:账户未设置FBA/FBC订单分配规则，22:表示仓库缺货的问题类型，23:表示仓库未找到SKU信息的问题类型,30:仓库拦截中
        /// </summary>
        public virtual byte? AbnormalType
        {
            get;
            set;
        }

        /// <summary>
        /// 异常信息
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string AbnormalReason
        {
            get;
            set;
        }

        /// <summary>
        /// 同步代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string SyncCode
        {
            get;
            set;
        }

        /// <summary>
        /// 是否拉取
        /// </summary>
        public virtual string IsPush
        {
            get;
            set;
        }

        /// <summary>
        /// 自定义订单类型
        /// 自定义订单类型
        /// 自定义订单类型
        /// 自定义订单类型
        /// 自定义订单类型
        /// 自定义订单类型
        /// 
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public virtual string CustomOrderType
        {
            get;
            set;
        }

        /// <summary>
        /// 订单标记状态
        /// </summary>
        public virtual string IsMark
        {
            get;
            set;
        }

        /// <summary>
        /// 客服备注
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string CustomerServiceNote
        {
            get;
            set;
        }

        /// <summary>
        /// 折扣
        /// </summary>
        public virtual string DiscountVal
        {
            get;
            set;
        }

        /// <summary>
        /// 是否需要发送邮件
        /// </summary>
        public virtual bool? NeedSendEmail
        {
            get;
            set;
        }

        /// <summary>
        /// 发货邮件
        /// </summary>
        public virtual bool? DeliverEmail
        {
            get;
            set;
        }

        public virtual ECOrderConfigData OrderConfigData
        {
            get;
            set;
        }

        public virtual IList<ECSalesOrderDetail> OrderDetails
        {
            get;
            set;
        }

        public virtual IList<BnsSendDeliverdToEc> BnsSendDeliverdToEcs
        {
            get;
            set;
        }

        public virtual ECSalesOrderAddress SalesOrderAddress
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
