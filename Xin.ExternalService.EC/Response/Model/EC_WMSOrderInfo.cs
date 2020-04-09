using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Xin.ExternalService.EC.Response.Model
{
    public class EC_WMSOrderInfo
    {
        [JsonProperty(PropertyName = "orderCode")]
        public string OrderCode { get; set; }
        [JsonProperty(PropertyName = "orderLog")]
        public List<OrderLog> OrderLog { get; set; }
        [JsonProperty(PropertyName = "orderStatus")]
        public OrderStatus OrderStatus { get; set; }
        [JsonProperty(PropertyName = "OpNode")]
        public List<OpNode> OpNode { get; set; }
        [JsonProperty(PropertyName = "product")]
        public List<Product> Product { get; set; }
        [JsonProperty(PropertyName = "order")]
        public Order Order { get; set; }
        [JsonProperty(PropertyName = "orderAddress")]
        public List<OrderAddress> OrderAddress { get; set; }
        [JsonProperty(PropertyName = "packingList")]
        public List<PackingList> PackingList { get; set; }
        [JsonProperty(PropertyName = "bb_service_provider_currency")]
        public string BbServiceProviderCurrency { get; set; }
        [JsonProperty(PropertyName = "orderTrack")]
        public List<Object> OrderTrack { get; set; }
        [JsonProperty(PropertyName = "syncConfirmShipStatusArr")]
        public string[] SyncConfirmShipStatusArr { get; set; }

        [JsonProperty(PropertyName = "odaTypeArr")]
        public OdaTypeArr OdaTypeArr { get; set; }
    }

    public class OdaTypeArr
    {
        [JsonProperty(PropertyName = "1", NullValueHandling = NullValueHandling.Ignore)]
        public string _1 { get; set; }
        [JsonProperty(PropertyName = "2", NullValueHandling = NullValueHandling.Ignore)]
        public string _2 { get; set; }
    }

    public class PackingList
    {




        /// <summary> 
        ///无
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TppId { get; set; }
        /// <summary> 
        ///装箱号
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_code", NullValueHandling = NullValueHandling.Ignore)]
        public string TppCode { get; set; }
        /// <summary> 
        ///序号 当信息变化时自加1
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_sn", NullValueHandling = NullValueHandling.Ignore)]
        public string TppSn { get; set; }
        /// <summary> 
        ///自定义箱号
        /// <summary> 
        [JsonProperty(PropertyName = "reference_no", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceNo { get; set; }
        /// <summary> 
        ///板号
        /// <summary> 
        [JsonProperty(PropertyName = "tpt_code", NullValueHandling = NullValueHandling.Ignore)]
        public string TptCode { get; set; }
        /// <summary> 
        ///运输方式
        /// <summary> 
        [JsonProperty(PropertyName = "sm_code", NullValueHandling = NullValueHandling.Ignore)]
        public string SmCode { get; set; }
        /// <summary> 
        ///订单ID
        /// <summary> 
        [JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; set; }
        /// <summary> 
        ///订单号
        /// <summary> 
        [JsonProperty(PropertyName = "order_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCode { get; set; }
        /// <summary> 
        ///仓库ID
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseId { get; set; }
        /// <summary> 
        ///目的仓库ID
        /// <summary> 
        [JsonProperty(PropertyName = "to_warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ToWarehouseId { get; set; }
        /// <summary> 
        ///创建人用户ID
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_creater_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TppCreaterId { get; set; }
        /// <summary> 
        ///操作完成人员ID
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_complete_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TppCompleteId { get; set; }
        /// <summary> 
        ///产品总数
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string TppQuantity { get; set; }
        /// <summary> 
        ///长度
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_length", NullValueHandling = NullValueHandling.Ignore)]
        public string TppLength { get; set; }
        /// <summary> 
        ///宽度
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_width", NullValueHandling = NullValueHandling.Ignore)]
        public string TppWidth { get; set; }
        /// <summary> 
        ///高度
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_height", NullValueHandling = NullValueHandling.Ignore)]
        public string TppHeight { get; set; }
        /// <summary> 
        ///总毛重(KG)
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_weight", NullValueHandling = NullValueHandling.Ignore)]
        public string TppWeight { get; set; }
        /// <summary> 
        ///总净重(KG)
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_net_weight", NullValueHandling = NullValueHandling.Ignore)]
        public string TppNetWeight { get; set; }
        /// <summary> 
        ///审核状态:0:无;1:待审核;2:通过审核;3:审核未通过
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_isverify", NullValueHandling = NullValueHandling.Ignore)]
        public string TppIsverify { get; set; }
        /// <summary> 
        ///状态:0:草稿;1:装载中;2:装载完成;3:加挂订单;4:已发货
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_status", NullValueHandling = NullValueHandling.Ignore)]
        public string TppStatus { get; set; }
        /// <summary> 
        ///收货状态，0草稿；1收货中；2收货完成
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_receiving_status", NullValueHandling = NullValueHandling.Ignore)]
        public string TppReceivingStatus { get; set; }
        /// <summary> 
        ///是否包含电池;0:无;1:有
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_isbattery", NullValueHandling = NullValueHandling.Ignore)]
        public string TppIsbattery { get; set; }
        /// <summary> 
        ///创建时间
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_add_time", NullValueHandling = NullValueHandling.Ignore)]
        public string TppAddTime { get; set; }
        /// <summary> 
        ///最后更新时间
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_update_time", NullValueHandling = NullValueHandling.Ignore)]
        public string TppUpdateTime { get; set; }
        /// <summary> 
        ///审核时间
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_excute_time", NullValueHandling = NullValueHandling.Ignore)]
        public string TppExcuteTime { get; set; }
        /// <summary> 
        ///上架状态，0草稿；1处理中；2已完成
        /// <summary> 
        [JsonProperty(PropertyName = "tpp_putaway_status", NullValueHandling = NullValueHandling.Ignore)]
        public string TppPutawayStatus { get; set; }
        /// <summary> 
        ///服务商币种
        /// <summary> 
        [JsonProperty(PropertyName = "bb_service_provider_currency", NullValueHandling = NullValueHandling.Ignore)]
        public string BbServiceProviderCurrency { get; set; }
        /// <summary> 
        ///包材信息
        /// <summary> 
        [JsonProperty(PropertyName = "packageInfo", NullValueHandling = NullValueHandling.Ignore)]
        public PackageInfo PackageInfo { get; set; }
    }

    public class PackageInfo
    {


        /// <summary> 
        ///包材所属仓库ID
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseId { get; set; }
        /// <summary> 
        ///单位
        /// <summary> 
        [JsonProperty(PropertyName = "ppu_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PpuCode { get; set; }
        /// <summary> 
        ///
        /// <summary> 
        [JsonProperty(PropertyName = "customer_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerCode { get; set; }
        /// <summary> 
        ///customer_id:客户ID; 另0:公用包材
        /// <summary> 
        [JsonProperty(PropertyName = "customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; set; }
        /// <summary> 
        ///包材条码
        /// <summary> 
        [JsonProperty(PropertyName = "pp_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string PpBarcode { get; set; }
        /// <summary> 
        ///'0:公用包材;1:客户自送包材'
        /// <summary> 
        [JsonProperty(PropertyName = "pp_type", NullValueHandling = NullValueHandling.Ignore)]
        public string PpType { get; set; }
        /// <summary> 
        ///'状态:0:不可用,1可用'
        /// <summary> 
        [JsonProperty(PropertyName = "pp_status", NullValueHandling = NullValueHandling.Ignore)]
        public string PpStatus { get; set; }
        /// <summary> 
        ///'按用途类型划分包材 0订单包材 1产品包材'
        /// <summary> 
        [JsonProperty(PropertyName = "pp_action_type", NullValueHandling = NullValueHandling.Ignore)]
        public string PpActionType { get; set; }
        /// <summary> 
        ///剩余包材数量
        /// <summary> 
        [JsonProperty(PropertyName = "pp_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string PpQuantity { get; set; }
        /// <summary> 
        ///包材费用
        /// <summary> 
        [JsonProperty(PropertyName = "pp_cost", NullValueHandling = NullValueHandling.Ignore)]
        public string PpCost { get; set; }
        /// <summary> 
        ///货币CODE
        /// <summary> 
        [JsonProperty(PropertyName = "currency_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyCode { get; set; }
        /// <summary> 
        ///包材名称
        /// <summary> 
        [JsonProperty(PropertyName = "pp_name", NullValueHandling = NullValueHandling.Ignore)]
        public string PpName { get; set; }
        /// <summary> 
        ///包材英文名称
        /// <summary> 
        [JsonProperty(PropertyName = "pp_name_en", NullValueHandling = NullValueHandling.Ignore)]
        public string PpNameEn { get; set; }
        /// <summary> 
        ///包材容纳长度
        /// <summary> 
        [JsonProperty(PropertyName = "pp_length", NullValueHandling = NullValueHandling.Ignore)]
        public string PpLength { get; set; }
        /// <summary> 
        ///包材容纳高度
        /// <summary> 
        [JsonProperty(PropertyName = "pp_height", NullValueHandling = NullValueHandling.Ignore)]
        public string PpHeight { get; set; }
        /// <summary> 
        ///容纳宽度
        /// <summary> 
        [JsonProperty(PropertyName = "pp_width", NullValueHandling = NullValueHandling.Ignore)]
        public string PpWidth { get; set; }
        /// <summary> 
        ///包材重量
        /// <summary> 
        [JsonProperty(PropertyName = "pp_weight", NullValueHandling = NullValueHandling.Ignore)]
        public string PpWeight { get; set; }
        /// <summary> 
        ///添加日期
        /// <summary> 
        [JsonProperty(PropertyName = "pp_add_time", NullValueHandling = NullValueHandling.Ignore)]
        public string PpAddTime { get; set; }
        /// <summary> 
        ///最后更新时间
        /// <summary> 
        [JsonProperty(PropertyName = "pp_update_time", NullValueHandling = NullValueHandling.Ignore)]
        public string PpUpdateTime { get; set; }
        /// <summary> 
        ///图片路径
        /// <summary> 
        [JsonProperty(PropertyName = "pp_path", NullValueHandling = NullValueHandling.Ignore)]
        public string PpPath { get; set; }
    }

    public class Order
    {

        /// <summary> 
        ///
        /// <summary> 
        [JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; set; }
        /// <summary> 
        ///订单code
        /// <summary> 
        [JsonProperty(PropertyName = "order_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCode { get; set; }
        /// <summary> 
        ///客户Code
        /// <summary> 
        [JsonProperty(PropertyName = "customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; set; }
        /// <summary> 
        ///客户Code
        /// <summary> 
        [JsonProperty(PropertyName = "customer_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerCode { get; set; }
        /// <summary> 
        ///平台代码
        /// <summary> 
        [JsonProperty(PropertyName = "platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }
        /// <summary> 
        ///平台类型:sale,refund,resend
        /// <summary> 
        [JsonProperty(PropertyName = "order_platform_type", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderPlatformType { get; set; }
        /// <summary> 
        ///平台真实订单号
        /// <summary> 
        [JsonProperty(PropertyName = "order_platform_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderPlatformCode { get; set; }
        /// <summary> 
        ///创建类型:api,upload,hand
        /// <summary> 
        [JsonProperty(PropertyName = "create_type", NullValueHandling = NullValueHandling.Ignore)]
        public string CreateType { get; set; }
        /// <summary> 
        ///仓库号 标识
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseId { get; set; }
        /// <summary> 
        ///目的仓库
        /// <summary> 
        [JsonProperty(PropertyName = "to_warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ToWarehouseId { get; set; }
        /// <summary> 
        ///类型：0:普通 ;1:转仓;2:退货;3:重发
        /// <summary> 
        [JsonProperty(PropertyName = "order_type", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderType { get; set; }
        /// <summary> 
        ///国家二字码
        /// <summary> 
        [JsonProperty(PropertyName = "country_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; set; }
        /// <summary> 
        ///货运方式代码
        /// <summary> 
        [JsonProperty(PropertyName = "sm_code", NullValueHandling = NullValueHandling.Ignore)]
        public string SmCode { get; set; }
        /// <summary> 
        ///物品申报价值,下单时填写,非SKU加总
        /// <summary> 
        [JsonProperty(PropertyName = "parcel_declared_value", NullValueHandling = NullValueHandling.Ignore)]
        public string ParcelDeclaredValue { get; set; }
        /// <summary> 
        ///申报重量
        /// <summary> 
        [JsonProperty(PropertyName = "declared_weight", NullValueHandling = NullValueHandling.Ignore)]
        public string DeclaredWeight { get; set; }
        /// <summary> 
        ///运费估算
        /// <summary> 
        [JsonProperty(PropertyName = "shipping_fee_estimate", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippingFeeEstimate { get; set; }
        /// <summary> 
        ///币种Code
        /// <summary> 
        [JsonProperty(PropertyName = "currency_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyCode { get; set; }
        /// <summary> 
        ///物品内容描述（内装何物）下单时填写
        /// <summary> 
        [JsonProperty(PropertyName = "parcel_contents", NullValueHandling = NullValueHandling.Ignore)]
        public string ParcelContents { get; set; }
        /// <summary> 
        ///内件数量
        /// <summary> 
        [JsonProperty(PropertyName = "parcel_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string ParcelQuantity { get; set; }
        /// <summary> 
        ///0:删除;1:草稿;2:确认;3:异常;4:已提交;5:已打印;6:已下架;7:已打包;8:已装袋;9:装袋完成;10:已加挂;11:物流完成;12:物流发货;13:已签收
        /// <summary> 
        [JsonProperty(PropertyName = "order_status", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderStatus { get; set; }
        /// <summary> 
        ///出库状态 0:未处理 1:已装袋 2:装袋完成; 3:已加挂总单;4:总单已出库
        /// <summary> 
        [JsonProperty(PropertyName = "order_outbound_status", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderOutboundStatus { get; set; }
        /// <summary> 
        ///占用库存 1:是 0:否
        /// <summary> 
        [JsonProperty(PropertyName = "order_hold_inventory", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderHoldInventory { get; set; }
        /// <summary> 
        ///冻结状态 0:无 1:盘点
        /// <summary> 
        [JsonProperty(PropertyName = "order_hold_status", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderHoldStatus { get; set; }
        /// <summary> 
        ///异常状态 0:无 1:标记缺货
        /// <summary> 
        [JsonProperty(PropertyName = "order_exception_status", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderExceptionStatus { get; set; }
        /// <summary> 
        ///0:无,1:有
        /// <summary> 
        [JsonProperty(PropertyName = "problem_status", NullValueHandling = NullValueHandling.Ignore)]
        public string ProblemStatus { get; set; }
        /// <summary> 
        ///0:无;1:余额不足;2:库存不足;3:已截单
        /// <summary> 
        [JsonProperty(PropertyName = "underreview_status", NullValueHandling = NullValueHandling.Ignore)]
        public string UnderreviewStatus { get; set; }
        /// <summary> 
        ///拦截状态 0:无;1:申请拦截;2:拦截中;3:拦截失败
        /// <summary> 
        [JsonProperty(PropertyName = "intercept_status", NullValueHandling = NullValueHandling.Ignore)]
        public string InterceptStatus { get; set; }
        /// <summary> 
        ///同步费用状态 0:未同步;1:已同步;2:同步异常
        /// <summary> 
        [JsonProperty(PropertyName = "sync_cost_status", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncCostStatus { get; set; }
        /// <summary> 
        ///同步状态 0:未同步;1:已同步;2:同步异常
        /// <summary> 
        [JsonProperty(PropertyName = "sync_status", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncStatus { get; set; }
        /// <summary> 
        ///等待状态0:无;1:物流处理
        /// <summary> 
        [JsonProperty(PropertyName = "order_waiting_status", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderWaitingStatus { get; set; }
        /// <summary> 
        ///下架打印顺序
        /// <summary> 
        [JsonProperty(PropertyName = "print_sort", NullValueHandling = NullValueHandling.Ignore)]
        public string PrintSort { get; set; }
        /// <summary> 
        ///标签打印次数
        /// <summary> 
        [JsonProperty(PropertyName = "print_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string PrintQuantity { get; set; }
        /// <summary> 
        ///订单加入时间
        /// <summary> 
        [JsonProperty(PropertyName = "add_time", NullValueHandling = NullValueHandling.Ignore)]
        public string AddTime { get; set; }
        /// <summary> 
        ///最后修改时间
        /// <summary> 
        [JsonProperty(PropertyName = "update_time", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdateTime { get; set; }
        /// <summary> 
        ///付款时间
        /// <summary> 
        [JsonProperty(PropertyName = "order_paydate", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderPaydate { get; set; }
        /// <summary> 
        ///订单类型:0:一票一件;1:一票一件多个;2;一票多件
        /// <summary> 
        [JsonProperty(PropertyName = "order_pick_type", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderPickType { get; set; }
        /// <summary> 
        ///客户参考号
        /// <summary> 
        [JsonProperty(PropertyName = "reference_no", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceNo { get; set; }
        /// <summary> 
        ///配货人ID
        /// <summary> 
        [JsonProperty(PropertyName = "picker_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PickerId { get; set; }
        /// <summary> 
        ///篮子号
        /// <summary> 
        [JsonProperty(PropertyName = "picking_basket", NullValueHandling = NullValueHandling.Ignore)]
        public string PickingBasket { get; set; }
        /// <summary> 
        ///备注
        /// <summary> 
        [JsonProperty(PropertyName = "remark", NullValueHandling = NullValueHandling.Ignore)]
        public string Remark { get; set; }
        /// <summary> 
        ///站点
        /// <summary> 
        [JsonProperty(PropertyName = "site_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteId { get; set; }
        /// <summary> 
        ///卖家ID
        /// <summary> 
        [JsonProperty(PropertyName = "seller_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SellerId { get; set; }
        /// <summary> 
        ///真正的卖家ID
        /// <summary> 
        [JsonProperty(PropertyName = "platform_seller_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PlatformSellerId { get; set; }
        /// <summary> 
        ///同步服务商标志。0：未同步、1：已同步 、2：已同步到EB、3：同步到Eb失败
        /// <summary> 
        [JsonProperty(PropertyName = "sync_service_status", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncServiceStatus { get; set; }
        /// <summary> 
        ///记录同步次数
        /// <summary> 
        [JsonProperty(PropertyName = "sync_count", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncCount { get; set; }
        /// <summary> 
        ///确认交运（暂时只有线上EUB订单使用） 0 未处理 1 已处理 2 处理异常
        /// <summary> 
        [JsonProperty(PropertyName = "sync_confirmship_status", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncConfirmshipStatus { get; set; }
        /// <summary> 
        ///API导入物流订单 0 未导入 1已导入 2同步异常
        /// <summary> 
        [JsonProperty(PropertyName = "sync_express_status", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncExpressStatus { get; set; }
        /// <summary> 
        ///物流跟踪标记 0 未发货 1 已发货 2 已签收
        /// <summary> 
        [JsonProperty(PropertyName = "sync_express_ship", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncExpressShip { get; set; }
        /// <summary> 
        ///该订单是否需要同步到服务商标志
        /// <summary> 
        [JsonProperty(PropertyName = "sync_required_sign", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncRequiredSign { get; set; }
        /// <summary> 
        ///系统备注
        /// <summary> 
        [JsonProperty(PropertyName = "operator_note", NullValueHandling = NullValueHandling.Ignore)]
        public string OperatorNote { get; set; }
        /// <summary> 
        ///同步OWMS状态 0:未同步 1:已同步 2:同步异常
        /// <summary> 
        [JsonProperty(PropertyName = "sync_wms_status", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncWmsStatus { get; set; }
        /// <summary> 
        ///是否允许同步WMS标识 0:否 1:是
        /// <summary> 
        [JsonProperty(PropertyName = "sync_wms_sign", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncWmsSign { get; set; }
        /// <summary> 
        ///同步时间
        /// <summary> 
        [JsonProperty(PropertyName = "sync_wms_time", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncWmsTime { get; set; }
        /// <summary> 
        ///需仓库确定实物真正的仓库配送方式
        /// <summary> 
        [JsonProperty(PropertyName = "check_shipping_method", NullValueHandling = NullValueHandling.Ignore)]
        public string CheckShippingMethod { get; set; }
        /// <summary> 
        ///需要或允许 1:重新预报
        /// <summary> 
        [JsonProperty(PropertyName = "anew_express_status", NullValueHandling = NullValueHandling.Ignore)]
        public string AnewExpressStatus { get; set; }
        /// <summary> 
        ///用于重发订单存放原始订单的跟踪号
        /// <summary> 
        [JsonProperty(PropertyName = "ref_tracking_number", NullValueHandling = NullValueHandling.Ignore)]
        public string RefTrackingNumber { get; set; }
        /// <summary> 
        ///预下架 0:未处理 1:已处理 2:异常
        /// <summary> 
        [JsonProperty(PropertyName = "order_advance_pickup", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderAdvancePickup { get; set; }
        /// <summary> 
        ///AMAZON FBA 费用
        /// <summary> 
        [JsonProperty(PropertyName = "fba_fee", NullValueHandling = NullValueHandling.Ignore)]
        public string FbaFee { get; set; }
        /// <summary> 
        ///订单创建人
        /// <summary> 
        [JsonProperty(PropertyName = "create_user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CreateUserId { get; set; }
        /// <summary> 
        ///是否为ODA件 1:是 0:否
        /// <summary> 
        [JsonProperty(PropertyName = "is_oda", NullValueHandling = NullValueHandling.Ignore)]
        public string IsOda { get; set; }
        /// <summary> 
        ///ODA类型 0:oda 1:偏远 2:超偏远
        /// <summary> 
        [JsonProperty(PropertyName = "oda_type", NullValueHandling = NullValueHandling.Ignore)]
        public string OdaType { get; set; }
        /// <summary> 
        ///是否是FBA订单，0-否 1-是
        /// <summary> 
        [JsonProperty(PropertyName = "is_fba", NullValueHandling = NullValueHandling.Ignore)]
        public string IsFba { get; set; }
        /// <summary> 
        ///是否是分销订单， 0-否 1-是
        /// <summary> 
        [JsonProperty(PropertyName = "is_shared", NullValueHandling = NullValueHandling.Ignore)]
        public string IsShared { get; set; }
        /// <summary> 
        ///导入电子面单图片，0-无 1-待导入 2-已导入 3-导入失败
        /// <summary> 
        [JsonProperty(PropertyName = "is_import_label", NullValueHandling = NullValueHandling.Ignore)]
        public string IsImportLabel { get; set; }
        /// <summary> 
        ///平台账号
        /// <summary> 
        [JsonProperty(PropertyName = "user_account", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAccount { get; set; }
        /// <summary> 
        ///平台用户
        /// <summary> 
        [JsonProperty(PropertyName = "platform_user_name", NullValueHandling = NullValueHandling.Ignore)]
        public string PlatformUserName { get; set; }
        /// <summary> 
        ///warehouse_code
        /// <summary> 
        [JsonProperty(PropertyName = "warehouse_code", NullValueHandling = NullValueHandling.Ignore)]
        public string WarehouseCode { get; set; }
        /// <summary> 
        ///配货人
        /// <summary> 
        [JsonProperty(PropertyName = "picker", NullValueHandling = NullValueHandling.Ignore)]
        public string Picker { get; set; }
        /// <summary> 
        ///物流信息
        /// <summary> 
        [JsonProperty(PropertyName = "ship", NullValueHandling = NullValueHandling.Ignore)]
        public Ship Ship { get; set; }
    }

    public class Ship
    {


        /// <summary> 
        ///追踪号
        /// <summary> 
        [JsonProperty(PropertyName = "tracking_number", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackingNumber { get; set; }
        /// <summary> 
        ///服务商转单号
        /// <summary> 
        [JsonProperty(PropertyName = "service_number_convert", NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceNumberConvert { get; set; }
        /// <summary> 
        ///服务商单号
        /// <summary> 
        [JsonProperty(PropertyName = "service_number", NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceNumber { get; set; }
        /// <summary> 
        ///出货包裹重量
        /// <summary> 
        [JsonProperty(PropertyName = "so_weight", NullValueHandling = NullValueHandling.Ignore)]
        public string SoWeight { get; set; }
        /// <summary> 
        ///运输费用
        /// <summary> 
        [JsonProperty(PropertyName = "so_shipping_fee", NullValueHandling = NullValueHandling.Ignore)]
        public string SoShippingFee { get; set; }
        /// <summary> 
        ///货币code
        /// <summary> 
        [JsonProperty(PropertyName = "currency_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyCode { get; set; }
    }

    public class OrderAddress
    {
        /// <summary> 
        ///无
        /// <summary> 
        [JsonProperty(PropertyName = "oab_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OabId { get; set; }
        /// <summary> 
        ///无
        /// <summary> 
        [JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; set; }
        /// <summary> 
        ///订单code
        /// <summary> 
        [JsonProperty(PropertyName = "order_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCode { get; set; }
        /// <summary> 
        ///名
        /// <summary> 
        [JsonProperty(PropertyName = "oab_firstname", NullValueHandling = NullValueHandling.Ignore)]
        public string OabFirstname { get; set; }
        /// <summary> 
        ///姓
        /// <summary> 
        [JsonProperty(PropertyName = "oab_lastname", NullValueHandling = NullValueHandling.Ignore)]
        public string OabLastname { get; set; }
        /// <summary> 
        ///公司
        /// <summary> 
        [JsonProperty(PropertyName = "oab_company", NullValueHandling = NullValueHandling.Ignore)]
        public string OabCompany { get; set; }
        /// <summary> 
        ///国家ID
        /// <summary> 
        [JsonProperty(PropertyName = "oab_country_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OabCountryId { get; set; }
        /// <summary> 
        ///zone
        /// <summary> 
        [JsonProperty(PropertyName = "oab_zone_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OabZoneId { get; set; }
        /// <summary> 
        ///邮编
        /// <summary> 
        [JsonProperty(PropertyName = "oab_postcode", NullValueHandling = NullValueHandling.Ignore)]
        public string OabPostcode { get; set; }
        /// <summary> 
        ///州/区域
        /// <summary> 
        [JsonProperty(PropertyName = "oab_state", NullValueHandling = NullValueHandling.Ignore)]
        public string OabState { get; set; }
        /// <summary> 
        ///city
        /// <summary> 
        [JsonProperty(PropertyName = "oab_city", NullValueHandling = NullValueHandling.Ignore)]
        public string OabCity { get; set; }
        /// <summary> 
        ///city
        /// <summary> 
        [JsonProperty(PropertyName = "oab_suburb", NullValueHandling = NullValueHandling.Ignore)]
        public string OabSuburb { get; set; }
        /// <summary> 
        ///地址1
        /// <summary> 
        [JsonProperty(PropertyName = "oab_street_address1", NullValueHandling = NullValueHandling.Ignore)]
        public string OabStreetAddress1 { get; set; }
        /// <summary> 
        ///地址2
        /// <summary> 
        [JsonProperty(PropertyName = "oab_street_address2", NullValueHandling = NullValueHandling.Ignore)]
        public string OabStreetAddress2 { get; set; }
        /// <summary> 
        ///门牌号
        /// <summary> 
        [JsonProperty(PropertyName = "oab_doorplate", NullValueHandling = NullValueHandling.Ignore)]
        public string OabDoorplate { get; set; }
        /// <summary> 
        ///电话
        /// <summary> 
        [JsonProperty(PropertyName = "oab_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string OabPhone { get; set; }
        /// <summary> 
        ///电话
        /// <summary> 
        [JsonProperty(PropertyName = "oab_cell_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string OabCellPhone { get; set; }
        /// <summary> 
        ///传真
        /// <summary> 
        [JsonProperty(PropertyName = "oab_fax", NullValueHandling = NullValueHandling.Ignore)]
        public string OabFax { get; set; }
        /// <summary> 
        ///电子邮件
        /// <summary> 
        [JsonProperty(PropertyName = "oab_email", NullValueHandling = NullValueHandling.Ignore)]
        public string OabEmail { get; set; }
        /// <summary> 
        ///备注
        /// <summary> 
        [JsonProperty(PropertyName = "oab_note", NullValueHandling = NullValueHandling.Ignore)]
        public string OabNote { get; set; }
        /// <summary> 
        ///更新时间
        /// <summary> 
        [JsonProperty(PropertyName = "oab_update_time", NullValueHandling = NullValueHandling.Ignore)]
        public string OabUpdateTime { get; set; }
        /// <summary> 
        ///国家及地区
        /// <summary> 
        [JsonProperty(PropertyName = "country", NullValueHandling = NullValueHandling.Ignore)]
        public Country Country { get; set; }
    }

    public class Country
    {
        /// <summary> 
        ///无
        /// <summary> 
        [JsonProperty(PropertyName = "country_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryId { get; set; }
        /// <summary> 
        ///中文名
        /// <summary> 
        [JsonProperty(PropertyName = "country_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryName { get; set; }
        /// <summary> 
        ///英文名
        /// <summary> 
        [JsonProperty(PropertyName = "country_name_en", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryNameEn { get; set; }
        /// <summary> 
        ///location name本国文字名字
        /// <summary> 
        [JsonProperty(PropertyName = "country_local_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryLocalName { get; set; }
        /// <summary> 
        ///别名
        /// <summary> 
        [JsonProperty(PropertyName = "country_alias", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryAlias { get; set; }
        /// <summary> 
        ///国际简称
        /// <summary> 
        [JsonProperty(PropertyName = "country_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; set; }
        /// <summary> 
        ///国家三字码
        /// <summary> 
        [JsonProperty(PropertyName = "country_code_iso", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCodeIso { get; set; }
        /// <summary> 
        ///ISO国家代码三位数字
        /// <summary> 
        [JsonProperty(PropertyName = "country_num", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryNum { get; set; }
        /// <summary> 
        ///排序 顺排
        /// <summary> 
        [JsonProperty(PropertyName = "country_sort", NullValueHandling = NullValueHandling.Ignore)]
        public string CountrySort { get; set; }
        /// <summary> 
        ///国家短名称
        /// <summary> 
        [JsonProperty(PropertyName = "country_short_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryShortName { get; set; }
        /// <summary> 
        ///海关国家编码
        /// <summary> 
        [JsonProperty(PropertyName = "trade_country", NullValueHandling = NullValueHandling.Ignore)]
        public string TradeCountry { get; set; }
        /// <summary> 
        ///其他相关名称
        /// <summary> 
        [JsonProperty(PropertyName = "country_match", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryMatch { get; set; }
        /// <summary> 
        ///国家状态（0，可用 1，停用）
        /// <summary> 
        [JsonProperty(PropertyName = "country_status", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryStatus { get; set; }
        /// <summary> 
        ///最后更新时间
        /// <summary> 
        [JsonProperty(PropertyName = "country_update_time", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryUpdateTime { get; set; }
    }

    public class Product
    {
        /// <summary> 
        ///无
        /// <summary> 
        [JsonProperty(PropertyName = "op_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OpId { get; set; }
        /// <summary> 
        ///无
        /// <summary> 
        [JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; set; }
        /// <summary> 
        ///订单code
        /// <summary> 
        [JsonProperty(PropertyName = "order_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCode { get; set; }
        /// <summary> 
        ///产品id
        /// <summary> 
        [JsonProperty(PropertyName = "product_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductId { get; set; }
        /// <summary> 
        ///产品唯一标示码
        /// <summary> 
        [JsonProperty(PropertyName = "product_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductBarcode { get; set; }
        /// <summary> 
        ///缺货数量
        /// <summary> 
        [JsonProperty(PropertyName = "op_oos", NullValueHandling = NullValueHandling.Ignore)]
        public string OpOos { get; set; }
        /// <summary> 
        ///缺货天数
        /// <summary> 
        [JsonProperty(PropertyName = "op_oos_days", NullValueHandling = NullValueHandling.Ignore)]
        public string OpOosDays { get; set; }
        /// <summary> 
        ///数量
        /// <summary> 
        [JsonProperty(PropertyName = "op_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string OpQuantity { get; set; }
        /// <summary> 
        ///占用库存数
        /// <summary> 
        [JsonProperty(PropertyName = "op_inventory", NullValueHandling = NullValueHandling.Ignore)]
        public string OpInventory { get; set; }
        /// <summary> 
        ///成交费(单价)
        /// <summary> 
        [JsonProperty(PropertyName = "op_final_value_fee", NullValueHandling = NullValueHandling.Ignore)]
        public string OpFinalValueFee { get; set; }
        /// <summary> 
        ///palpay手续费
        /// <summary> 
        [JsonProperty(PropertyName = "op_paypal_fee", NullValueHandling = NullValueHandling.Ignore)]
        public string OpPaypalFee { get; set; }
        /// <summary> 
        ///销售单价
        /// <summary> 
        [JsonProperty(PropertyName = "op_sales_price", NullValueHandling = NullValueHandling.Ignore)]
        public string OpSalesPrice { get; set; }
        /// <summary> 
        ///申报价值(单价)
        /// <summary> 
        [JsonProperty(PropertyName = "op_declared_value", NullValueHandling = NullValueHandling.Ignore)]
        public string OpDeclaredValue { get; set; }
        /// <summary> 
        ///申报重量
        /// <summary> 
        [JsonProperty(PropertyName = "op_declared_weight", NullValueHandling = NullValueHandling.Ignore)]
        public string OpDeclaredWeight { get; set; }
        /// <summary> 
        ///产品目录ID
        /// <summary> 
        [JsonProperty(PropertyName = "F37", NullValueHandling = NullValueHandling.Ignore)]
        public string F37 { get; set; }
        /// <summary> 
        ///paypal收款帐户
        /// <summary> 
        [JsonProperty(PropertyName = "op_recv_account", NullValueHandling = NullValueHandling.Ignore)]
        public string OpRecvAccount { get; set; }
        /// <summary> 
        ///Ref Transaction ID
        /// <summary> 
        [JsonProperty(PropertyName = "op_ref_tnx", NullValueHandling = NullValueHandling.Ignore)]
        public string OpRefTnx { get; set; }
        /// <summary> 
        ///Ref Item id
        /// <summary> 
        [JsonProperty(PropertyName = "op_ref_item_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OpRefItemId { get; set; }
        /// <summary> 
        ///买家ID
        /// <summary> 
        [JsonProperty(PropertyName = "op_ref_buyer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OpRefBuyerId { get; set; }
        /// <summary> 
        ///付款时间
        /// <summary> 
        [JsonProperty(PropertyName = "op_ref_paydate", NullValueHandling = NullValueHandling.Ignore)]
        public string OpRefPaydate { get; set; }
        /// <summary> 
        ///添加时间
        /// <summary> 
        [JsonProperty(PropertyName = "op_add_time", NullValueHandling = NullValueHandling.Ignore)]
        public string OpAddTime { get; set; }
        /// <summary> 
        ///最后修改时间
        /// <summary> 
        [JsonProperty(PropertyName = "op_update_time", NullValueHandling = NullValueHandling.Ignore)]
        public string OpUpdateTime { get; set; }
        /// <summary> 
        ///1:拍卖，2:一口价，3:一口价+拍卖
        /// <summary> 
        [JsonProperty(PropertyName = "item_list_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemListType { get; set; }
        /// <summary> 
        ///AMAZON FBA 费用
        /// <summary> 
        [JsonProperty(PropertyName = "op_fba_fee", NullValueHandling = NullValueHandling.Ignore)]
        public string OpFbaFee { get; set; }
        /// <summary> 
        ///其它费用
        /// <summary> 
        [JsonProperty(PropertyName = "op_other_fee", NullValueHandling = NullValueHandling.Ignore)]
        public string OpOtherFee { get; set; }
        /// <summary> 
        ///平台销售SKU
        /// <summary> 
        [JsonProperty(PropertyName = "op_platform_sales_sku", NullValueHandling = NullValueHandling.Ignore)]
        public string OpPlatformSalesSku { get; set; }
        /// <summary> 
        ///平台销售SKU数量
        /// <summary> 
        [JsonProperty(PropertyName = "op_platform_sales_quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string OpPlatformSalesQuantity { get; set; }
        /// <summary> 
        ///单个运费
        /// <summary> 
        [JsonProperty(PropertyName = "op_shipping_fee", NullValueHandling = NullValueHandling.Ignore)]
        public string OpShippingFee { get; set; }
        /// <summary> 
        ///重量
        /// <summary> 
        [JsonProperty(PropertyName = "product_weight", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductWeight { get; set; }
        /// <summary> 
        ///高度
        /// <summary> 
        [JsonProperty(PropertyName = "product_height", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductHeight { get; set; }
        /// <summary> 
        ///长度
        /// <summary> 
        [JsonProperty(PropertyName = "product_length", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductLength { get; set; }
        /// <summary> 
        ///宽度
        /// <summary> 
        [JsonProperty(PropertyName = "product_width", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductWidth { get; set; }
        /// <summary> 
        ///名称
        /// <summary> 
        [JsonProperty(PropertyName = "product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }
        /// <summary> 
        ///第三方仓库产品代码
        /// <summary> 
        [JsonProperty(PropertyName = "barcode_code", NullValueHandling = NullValueHandling.Ignore)]
        public List<BarcodeCode> BarcodeCode { get; set; }
    }

    public class BarcodeCode
    {
        public string WarehouseProductBarcode
        {
            get;
            set;
        }
        public string WarehouseDesc
        {
            get;
            set;
        }

        public string WarehouseCode
        {
            get;
            set;
        }
    }

    public class OpNode
    {
        /// <summary> 
        ///无
        /// <summary> 
        [JsonProperty(PropertyName = "oon_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OonId { get; set; }
        /// <summary> 
        ///无
        /// <summary> 
        [JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; set; }
        /// <summary> 
        ///订单code
        /// <summary> 
        [JsonProperty(PropertyName = "order_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCode { get; set; }
        /// <summary> 
        ///操作代码
        /// <summary> 
        [JsonProperty(PropertyName = "oot_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OotCode { get; set; }
        /// <summary> 
        ///备注
        /// <summary> 
        [JsonProperty(PropertyName = "oon_note", NullValueHandling = NullValueHandling.Ignore)]
        public string OonNote { get; set; }
        /// <summary> 
        ///发生时间
        /// <summary> 
        [JsonProperty(PropertyName = "oon_add_time", NullValueHandling = NullValueHandling.Ignore)]
        public string OonAddTime { get; set; }
        /// <summary> 
        ///0:SYSTEM/-1客户
        /// <summary> 
        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        /// <summary> 
        ///操作人员
        /// <summary> 
        [JsonProperty(PropertyName = "user_name", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }
        /// <summary> 
        ///动作
        /// <summary> 
        [JsonProperty(PropertyName = "oot_name", NullValueHandling = NullValueHandling.Ignore)]
        public string OotName { get; set; }
        /// <summary> 
        ///动作英文名
        /// <summary> 
        [JsonProperty(PropertyName = "oot_name_en", NullValueHandling = NullValueHandling.Ignore)]
        public string OotNameEn { get; set; }
    }

    public class OrderStatus
    {
        /// <summary> 
        ///删除
        /// <summary> 
        [JsonProperty(PropertyName = "0", NullValueHandling = NullValueHandling.Ignore)]
        public string _0 { get; set; }
        /// <summary> 
        ///草稿
        /// <summary> 
        [JsonProperty(PropertyName = "1", NullValueHandling = NullValueHandling.Ignore)]
        public string _1 { get; set; }
        /// <summary> 
        ///确认
        /// <summary> 
        [JsonProperty(PropertyName = "2", NullValueHandling = NullValueHandling.Ignore)]
        public string _2 { get; set; }
        /// <summary> 
        ///缺货
        /// <summary> 
        [JsonProperty(PropertyName = "3", NullValueHandling = NullValueHandling.Ignore)]
        public string _3 { get; set; }
        /// <summary> 
        ///已提交
        /// <summary> 
        [JsonProperty(PropertyName = "4", NullValueHandling = NullValueHandling.Ignore)]
        public string _4 { get; set; }
        /// <summary> 
        ///已打印
        /// <summary> 
        [JsonProperty(PropertyName = "5", NullValueHandling = NullValueHandling.Ignore)]
        public string _5 { get; set; }
        /// <summary> 
        ///已打包
        /// <summary> 
        [JsonProperty(PropertyName = "7", NullValueHandling = NullValueHandling.Ignore)]
        public string _7 { get; set; }
        /// <summary> 
        ///已出库
        /// <summary> 
        [JsonProperty(PropertyName = "8", NullValueHandling = NullValueHandling.Ignore)]
        public string _8 { get; set; }
        /// <summary> 
        ///已出库
        /// <summary> 
        [JsonProperty(PropertyName = "10", NullValueHandling = NullValueHandling.Ignore)]
        public string _10 { get; set; }
    }

    public class OrderLog
    {
        /// <summary> 
        ///无
        /// <summary> 
        [JsonProperty(PropertyName = "ol_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OlId { get; set; }
        /// <summary> 
        ///订单id
        /// <summary> 
        [JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; set; }
        /// <summary> 
        ///订单code
        /// <summary> 
        [JsonProperty(PropertyName = "order_code", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderCode { get; set; }
        /// <summary> 
        ///变更类型,0状态;1内容
        /// <summary> 
        [JsonProperty(PropertyName = "ol_type", NullValueHandling = NullValueHandling.Ignore)]
        public string OlType { get; set; }
        /// <summary> 
        ///变化前状态
        /// <summary> 
        [JsonProperty(PropertyName = "order_status_from", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderStatusFrom { get; set; }
        /// <summary> 
        ///变化后状态
        /// <summary> 
        [JsonProperty(PropertyName = "order_status_to", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderStatusTo { get; set; }
        /// <summary> 
        ///发生时间
        /// <summary> 
        [JsonProperty(PropertyName = " ol_add_time", NullValueHandling = NullValueHandling.Ignore)]
        public string olAddTime { get; set; }
        /// <summary> 
        ///0:SYSTEM/-1客户自操作
        /// <summary> 
        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        /// <summary> 
        ///访问IP
        /// <summary> 
        [JsonProperty(PropertyName = "ol_ip", NullValueHandling = NullValueHandling.Ignore)]
        public string OlIp { get; set; }
        /// <summary> 
        ///备注
        /// <summary> 
        [JsonProperty(PropertyName = "ol_comments", NullValueHandling = NullValueHandling.Ignore)]
        public string OlComments { get; set; }
        /// <summary> 
        ///操作人员
        /// <summary> 
        [JsonProperty(PropertyName = "user_name", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }
    }


}
