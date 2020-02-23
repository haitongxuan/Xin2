using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Xin.ExternalService.EC.Reqeust.Model
{
    public class EBGetOrderListReqModel
    {
        /// <summary>
        /// 页数
        /// </summary>
        [JsonProperty(PropertyName = "page", NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        [JsonProperty(PropertyName = "pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }

        /// <summary>
        /// 是否返回订单明细数据
        /// </summary>
        [JsonProperty(PropertyName = "getDetail", NullValueHandling = NullValueHandling.Ignore)]
        public IsOrNotEnum? GetDetail { get; set; }

        /// <summary>
        /// 是否返回订单地址数据
        /// </summary>
        [JsonProperty(PropertyName = "getAddress", NullValueHandling = NullValueHandling.Ignore)]
        public IsOrNotEnum? GetAddress { get; set; }

        /// <summary>
        /// 按年份查询订单，传年份：2019 请在订单系统平台订单查看是否支持按年份查询，不支持的不要传此参数
        /// </summary>
        [JsonProperty(PropertyName = "year", NullValueHandling = NullValueHandling.Ignore)]
        public int? Year { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        [JsonProperty(PropertyName = "condition", NullValueHandling = NullValueHandling.Ignore)]
        public Conditions Condition { get; set; }
    }
    public class Conditions {

        /// <summary>
        /// 查询条件
        /// </summary>
        [JsonProperty(PropertyName = "refNos", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> RefNos { get; set; }

        /// <summary>
        /// 参考号列表，如：["CODE1","CODE2","CODE3"]
        /// </summary>
        [JsonProperty(PropertyName = "condition", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Condition { get; set; }

        /// <summary>
        /// 销售单号，如：["CODE1","CODE2","CODE3"]
        /// </summary>
        [JsonProperty(PropertyName = "saleOrderCodes", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> SaleOrderCodes { get; set; }

        /// <summary>
        /// 仓库单号，如：["CODE1","CODE2","CODE3"]
        /// </summary>
        [JsonProperty(PropertyName = "warehouseOrderCodes", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> WarehouseOrderCodes { get; set; }

        /// <summary>
        /// 仓库sku，如：["CODE1","CODE2","CODE3"]
        /// </summary>
        [JsonProperty(PropertyName = "productSku", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ProductSku { get; set; }

        /// <summary>
        /// 平台账号，如：["CODE1","CODE2","CODE3"]
        /// </summary>
        [JsonProperty(PropertyName = "userAccounts", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> UserAccounts { get; set; }

        /// <summary>
        /// 运输方式代码，如：["CODE1","CODE2","CODE3"]
        /// </summary>
        [JsonProperty(PropertyName = "shippingMethod", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ShippingMethod { get; set; }

        /// <summary>
        /// 仓库ID，如：["45","78","62"]，通过相关接口->getWarehouse接口获取仓库ID
        /// </summary>
        [JsonProperty(PropertyName = "warehouseIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> WarehouseIds { get; set; }

        /// <summary>
        /// 订单状态，0:已废弃,1:付款未完成,2:待发货审核,3:待发货,4:已发货,5:冻结中,6:缺货,7:问题件,8:未付款
        /// </summary>
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public StatusEnum? Status { get; set; }

        /// <summary>
        /// 待发货下的处理状态，如：["1","2"]，1:已处理,2:未处理，3：处理异常	
        /// </summary>
        [JsonProperty(PropertyName = "processAgains", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ProcessAgains { get; set; }

        /// <summary>
        /// 最早创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createdDateAfter", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedDateAfter { get; set; }

        /// <summary>
        /// 最晚创建时间
        /// </summary>
        [JsonProperty(PropertyName = "createdDateBefore", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedDateBefore { get; set; }

        /// <summary>
        /// 最早更新时间
        /// </summary>
        [JsonProperty(PropertyName = "updateDateAfter", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdateDateAfter { get; set; }

        /// <summary>
        /// 最晚更新时间
        /// </summary>
        [JsonProperty(PropertyName = "updateDateBefore", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdateDateBefore { get; set; }

        /// <summary>
        /// 最早发货时间
        /// </summary>
        [JsonProperty(PropertyName = "shipDateFrom", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ShipDateFrom { get; set; }

        /// <summary>
        /// 最晚发货时间
        /// </summary>
        [JsonProperty(PropertyName = "shipDateEnd", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ShipDateEnd { get; set; }

        /// <summary>
        /// 平台发货时间始	
        /// </summary>
        [JsonProperty(PropertyName = "platformShipDateFrom", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PlatformShipDateFrom { get; set; }

        /// <summary>
        /// 平台发货时间尾	
        /// </summary>
        [JsonProperty(PropertyName = "platformShipDateEnd", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PlatformShipDateEnd { get; set; }

        /// <summary>
        /// 仓库发货时间始	
        /// </summary>
        [JsonProperty(PropertyName = "warehouseShipDateFrom", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? WarehouseShipDateFrom { get; set; }

        /// <summary>
        /// 仓库发货时间尾	
        /// </summary>
        [JsonProperty(PropertyName = "warehouseShipDateEnd", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? WarehouseShipDateEnd { get; set; }

        /// <summary>
        /// 买家名称	
        /// </summary>
        [JsonProperty(PropertyName = "buyerName", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerName { get; set; }

        /// <summary>
        /// 平台代码，aliexpresscn为1688采购单	
        /// </summary>
        [JsonProperty(PropertyName = "platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }
        /// <summary>
        /// 是否按id 降序 0:升序 1:降序		
        /// </summary>
        [JsonProperty(PropertyName = "idDesc", NullValueHandling = NullValueHandling.Ignore)]
        public IdSortEnum? IdDesc { get; set; }
    }

    /// <summary>
    /// 状态
    /// </summary>
    public enum StatusEnum { 
    
        已废弃 = 0,
        付款未完成 = 1,
        待发货审核=2,
        待发货 =3,
        已发货 =4,
        冻结中 =5,
        缺货 =6,
        问题件 = 7,
        未付款 = 8
    }
    ///// <summary>
    ///// 代发货下的处理状态
    ///// </summary>
    //public enum ProcessAgainsEnum { 
    
    //    已处理=1,
    //    未处理=2,
    //    处理异常=3
    //}
    /// <summary>
    /// 是否按ID排序
    /// </summary>
    public enum IdSortEnum { 
    
        升序=0,
        降序=1
    }
}