using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Xin.ExternalService.EC.Reqeust.Model
{
    public class WMSGetProductListReqModel
    {
        /// <summary>
        /// 产品SKU
        /// </summary>
        [JsonProperty(PropertyName = "productSku", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSku { get; set; }

        /// <summary>
        /// 产品SKU模糊查询
        /// </summary>
        [JsonProperty(PropertyName = "productSkuLike", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSkuLike { get; set; }

        /// <summary>
        /// 产品款式代码
        /// </summary>
        [JsonProperty(PropertyName = "productSpu", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductSpu { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [JsonProperty(PropertyName = "productTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }

        /// <summary>
        /// 产品名称模糊查询
        /// </summary>
        [JsonProperty(PropertyName = "productTitleLike", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitleLike { get; set; }

        /// <summary>
        /// 仓库条码
        /// </summary>
        [JsonProperty(PropertyName = "warehouseBarcode", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseBarcode { get; set; }

        /// <summary>
        /// 仓库条码模糊查询
        /// </summary>
        [JsonProperty(PropertyName = "warehouseBarcodeLike", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseBarcodeLike { get; set; }

        /// <summary>
        /// 默认供应商代码。提供接口getAllSupplier查询
        /// </summary>
        [JsonProperty(PropertyName = "defaultSupplierCode", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultSupplierCode { get; set; }

        /// <summary>
        /// 产品创建时间-开始时间
        /// </summary>
        [JsonProperty(PropertyName = "productAddTimeFrom", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ProductAddTimeFrom { get; set; }

        /// <summary>
        /// 产品创建时间-截止时间
        /// </summary>
        [JsonProperty(PropertyName = "productAddTimeTo", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ProductAddTimeTo { get; set; }

        /// <summary>
        /// 产品更新时间-开始时间
        /// </summary>
        [JsonProperty(PropertyName = "productUpdateTimeFrom", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ProductUpdateTimeFrom { get; set; }

        /// <summary>
        /// 产品更新时间-截止时间
        /// </summary>
        [JsonProperty(PropertyName = "productUpdateTimeTo", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ProductUpdateTimeTo { get; set; }

        /// <summary>
        /// 审核时间-开始时间
        /// </summary>
        [JsonProperty(PropertyName = "productReleaseTimeFrom", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ProductReleaseTimeFrom { get; set; }

        /// <summary>
        /// 审核时间-截止时间
        /// </summary>
        [JsonProperty(PropertyName = "productReleaseTimeTo", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ProductReleaseTimeTo { get; set; }

        /// <summary>
        /// 产品状态:0 不可用,1可用,2:开发产品,
        /// </summary>
        [JsonProperty(PropertyName = "productStatus", NullValueHandling = NullValueHandling.Ignore)]
        public ProductStatusEnum? ProductStatus { get; set; }

        /// <summary>
        /// 产品销售状态Id
        /// </summary>
        [JsonProperty(PropertyName = "saleStatus", NullValueHandling = NullValueHandling.Ignore)]
        public int? SaleStatus { get; set; }

        /// <summary>
        /// 是否质检 0否 1是
        /// </summary>
        [JsonProperty(PropertyName = "isQc", NullValueHandling = NullValueHandling.Ignore)]
        public IsOrNotEnum? IsQc { get; set; }

        /// <summary>
        /// 是否存在有效期
        /// </summary>
        [JsonProperty(PropertyName = "isExpDate", NullValueHandling = NullValueHandling.Ignore)]
        public IsOrNotEnum? IsExpDate { get; set; }

        /// <summary>
        /// 是否赠品
        /// </summary>
        [JsonProperty(PropertyName = "isGift", NullValueHandling = NullValueHandling.Ignore)]
        public IsOrNotEnum? IsGift { get; set; }

        /// <summary>
        /// 采购负责人Id
        /// </summary>
        [JsonProperty(PropertyName = "personOpraterId", NullValueHandling = NullValueHandling.Ignore)]
        public int? PersonOpraterId { get; set; }

        /// <summary>
        /// 产品等级Id，数据可自定义。提供接口getProductLevel查询
        /// </summary>
        [JsonProperty(PropertyName = "prl_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Prl_id { get; set; }

        /// <summary>
        /// 是否是组合产品
        /// </summary>
        [JsonProperty(PropertyName = "isCombination", NullValueHandling = NullValueHandling.Ignore)]
        public IsOrNotEnum? IsCombination { get; set; }

        /// <summary>
        /// 产品SKU
        /// </summary>
        [JsonProperty(PropertyName = "getProductCombination", NullValueHandling = NullValueHandling.Ignore)]
        public IsOrNotEnum? GetProductCombination { get; set; }

        /// <summary>
        /// 获取产品箱规信息
        /// </summary>
        [JsonProperty(PropertyName = "getProductBox", NullValueHandling = NullValueHandling.Ignore)]
        public IsOrNotEnum? GetProductBox { get; set; }

        /// <summary>
        /// 获取产品自定义属性
        /// </summary>
        [JsonProperty(PropertyName = "getProperty", NullValueHandling = NullValueHandling.Ignore)]
        public IsOrNotEnum? GetProperty { get; set; }

        /// <summary>
        /// 获取产品自定义分类
        /// </summary>
        [JsonProperty(PropertyName = "getProductCustomCategory", NullValueHandling = NullValueHandling.Ignore)]
        public IsOrNotEnum? GetProductCustomCategory { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        [JsonProperty(PropertyName = "page", NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }

        /// <summary>
        /// 每一页条数，最大1000
        /// </summary>
        [JsonProperty(PropertyName = "pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }



    }
    /// <summary>
    /// 产品状态
    /// </summary>
    public enum ProductStatusEnum
    {
        不可用 = 0,
        可用 = 1,
        开发产品 = 2
    }
    /// <summary>
    /// YesOrNo
    /// </summary>
    public enum IsOrNotEnum
    {

        No = 0,
        Yes = 1
    }
}
