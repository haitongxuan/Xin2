﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2020/5/21 17:08:34
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
    public partial class ECProduct {

        public ECProduct()
        {
            this.ProductBoxes = new List<ECProductBox>();
            this.ProductCombinations = new List<ECProductCombination>();
            this.ProductCustomCategories = new List<ECProductCustomCategory>();
            this.ProductProperties = new List<ECProductProperty>();
            OnCreated();
        }

        /// <summary>
        /// 产品SKU代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual string ProductSku
        {
            get;
            set;
        }

        /// <summary>
        /// 名称CN
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProductTitle
        {
            get;
            set;
        }

        /// <summary>
        /// 名称EN
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProductTitleEn
        {
            get;
            set;
        }

        /// <summary>
        /// 产品款式代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProductSpu
        {
            get;
            set;
        }

        /// <summary>
        /// 申报价值
        /// </summary>
        public virtual decimal? ProductDeclaredValue
        {
            get;
            set;
        }

        /// <summary>
        /// 申报币种：例如USD
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        public virtual string PdDeclareCurrencyCode
        {
            get;
            set;
        }

        /// <summary>
        /// 重量，单位Kg
        /// </summary>
        public virtual decimal? ProductWeight
        {
            get;
            set;
        }

        /// <summary>
        /// 净重，单位Kg
        /// </summary>
        public virtual decimal? ProductNetWeight
        {
            get;
            set;
        }

        /// <summary>
        /// 默认供应商代码。提供接口getAllSupplier查询
        ///    
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string DefaultSupplierCode
        {
            get;
            set;
        }

        /// <summary>
        /// 产品状态: 0:不可用,1:可用,2:开发产品
        /// </summary>
        public virtual int? ProductStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 产品销售状态Id，数据可自定义。提供接口getSaleStatus查询
        /// </summary>
        public virtual int? SaleStatus
        {
            get;
            set;
        }

        /// <summary>
        /// 是否质检 0否 1是
        /// </summary>
        public virtual bool? IsQc
        {
            get;
            set;
        }

        /// <summary>
        /// 是否存在有效期 0否 1是
        /// </summary>
        public virtual bool? IsExpDate
        {
            get;
            set;
        }

        /// <summary>
        /// 是否赠品 0否 1是
        /// </summary>
        public virtual bool? IsGift
        {
            get;
            set;
        }

        /// <summary>
        /// 仓库条码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string WarehouseBarcode
        {
            get;
            set;
        }

        /// <summary>
        /// 产品长度，单位CM
        /// </summary>
        public virtual decimal? ProductLength
        {
            get;
            set;
        }

        /// <summary>
        /// 产品宽度，单位CM
        /// </summary>
        public virtual decimal? ProductWidth
        {
            get;
            set;
        }

        /// <summary>
        /// 产品高度，单位CM
        /// </summary>
        public virtual decimal? ProductHeight
        {
            get;
            set;
        }

        /// <summary>
        /// 设计师Id
        /// </summary>
        public virtual int? DesignerId
        {
            get;
            set;
        }

        /// <summary>
        /// 采购负责人Id
        /// </summary>
        public virtual int? PersonOpraterId
        {
            get;
            set;
        }

        /// <summary>
        /// 销售负责人Id
        /// </summary>
        public virtual int? PersonSellerId
        {
            get;
            set;
        }

        /// <summary>
        /// 开发负责人Id
        /// </summary>
        public virtual int? PersonDevelopId
        {
            get;
            set;
        }

        /// <summary>
        /// 产品创建时间
        /// </summary>
        public virtual System.DateTime? ProductAddTime
        {
            get;
            set;
        }

        /// <summary>
        /// 产品更新时间
        /// </summary>
        public virtual System.DateTime? ProductUpdateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 审核时间
        /// </summary>
        public virtual System.DateTime? PpnReleaseDate
        {
            get;
            set;
        }

        /// <summary>
        /// 是否是组合产品 ， 0否 1是
        /// </summary>
        public virtual int? IsCombination
        {
            get;
            set;
        }

        /// <summary>
        /// 产品颜色Id，数据可自定义。提供接口getProductColor查询
        /// </summary>
        public virtual int? ProductColorId
        {
            get;
            set;
        }

        /// <summary>
        /// 产品尺寸Id，数据可自定义。提供接口getProductSize查询
        /// </summary>
        public virtual int? ProductSizeId
        {
            get;
            set;
        }

        /// <summary>
        /// 单位名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PuName
        {
            get;
            set;
        }

        /// <summary>
        /// 组织机构ID
        /// </summary>
        public virtual int? UserOrganizationId
        {
            get;
            set;
        }

        /// <summary>
        /// 默认发货仓库ID
        /// </summary>
        public virtual int? DefaultWarehouseId
        {
            get;
            set;
        }

        /// <summary>
        /// EAN码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string EanCode
        {
            get;
            set;
        }

        /// <summary>
        /// 一级品类代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProcutCategoryCode1
        {
            get;
            set;
        }

        /// <summary>
        /// 二级品类代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProcutCategoryCode2
        {
            get;
            set;
        }

        /// <summary>
        /// 三级品类代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProcutCategoryCode3
        {
            get;
            set;
        }

        /// <summary>
        /// 一级品类名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProcutCategoryName1
        {
            get;
            set;
        }

        /// <summary>
        /// 二级品类名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProcutCategoryName2
        {
            get;
            set;
        }

        /// <summary>
        /// 三级品类名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string ProcutCategoryName3
        {
            get;
            set;
        }

        /// <summary>
        /// 运营方式：1代运营、2自运营
        /// </summary>
        public virtual int? OprationType
        {
            get;
            set;
        }

        /// <summary>
        /// 品牌代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string BrandCode
        {
            get;
            set;
        }

        /// <summary>
        /// 品牌名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string BrandName
        {
            get;
            set;
        }

        /// <summary>
        /// 产品级别代码
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PrlCode
        {
            get;
            set;
        }

        /// <summary>
        /// 产品级别名称
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string PrlName
        {
            get;
            set;
        }

        /// <summary>
        /// 供应商产品币种
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CurrencyCode
        {
            get;
            set;
        }

        /// <summary>
        /// 供应商产品单价
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string SpUnitPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 图片链接
        /// </summary>
        [System.ComponentModel.DataAnnotations.StringLength(4000)]
        public virtual string ProductImages
        {
            get;
            set;
        }

        public virtual int? DefaulBuyWarehouseId
        {
            get;
            set;
        }

        public virtual string LogisticAttribute
        {
            get;
            set;
        }

        public virtual decimal? SuggestPrice
        {
            get;
            set;
        }

        public virtual string SuggestPriceCurrencyCode
        {
            get;
            set;
        }

        public virtual IList<ECProductBox> ProductBoxes
        {
            get;
            set;
        }

        public virtual IList<ECProductCombination> ProductCombinations
        {
            get;
            set;
        }

        public virtual IList<ECProductCustomCategory> ProductCustomCategories
        {
            get;
            set;
        }

        public virtual IList<ECProductProperty> ProductProperties
        {
            get;
            set;
        }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
