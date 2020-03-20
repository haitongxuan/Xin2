using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.ExternalService.EC.WMS.Response.Model
{
    public class QueryFbaOrderResponseModel
    {
        [JsonProperty(PropertyName = "fba_order", NullValueHandling = NullValueHandling.Ignore)]
        public FbaOrder FbaOrder { get; set; }
        [JsonProperty(PropertyName = "fba_box", NullValueHandling = NullValueHandling.Ignore)]
        public FbaBox FbaBox { get; set; }
        [JsonProperty(PropertyName = "fba_box_detail", NullValueHandling = NullValueHandling.Ignore)]
        public List<FbaBoxDetail> FbaBoxDetail { get; set; }

        [JsonProperty(PropertyName = "fba_pack", NullValueHandling = NullValueHandling.Ignore)]
        public List<FbaPackBox> FbaPack { get; set; }

        [JsonProperty(PropertyName = "fba_pack_detail", NullValueHandling = NullValueHandling.Ignore)]
        public List<FbaPackDetail> FbaPackDetail { get; set; }

        [JsonProperty(PropertyName = "fba_order_log", NullValueHandling = NullValueHandling.Ignore)]
        public List<FbaLog> FbaOrderLog { get; set; }
    }

    public class FbaOrder
    {
        [JsonProperty(PropertyName = "fba_code", NullValueHandling = NullValueHandling.Ignore)]
        public string FbaCode { get; set; }
        [JsonProperty(PropertyName = "amazon_shipment", NullValueHandling = NullValueHandling.Ignore)]
        public string AmazonShipment { get; set; }
        [JsonProperty(PropertyName = "amazon_reference", NullValueHandling = NullValueHandling.Ignore)]
        public string AmazonReference { get; set; }
        [JsonProperty(PropertyName = "sm_type", NullValueHandling = NullValueHandling.Ignore)]
        public int SmType { get; set; }
        [JsonProperty(PropertyName = "fba_type", NullValueHandling = NullValueHandling.Ignore)]
        public int FbaType { get; set; }
        [JsonProperty(PropertyName = "stock_type", NullValueHandling = NullValueHandling.Ignore)]
        public int StockType { get; set; }
        [JsonProperty(PropertyName = "fba_status", NullValueHandling = NullValueHandling.Ignore)]
        public int FbaStatus { get; set; }
        [JsonProperty(PropertyName = "exception_status", NullValueHandling = NullValueHandling.Ignore)]
        public int ExceptionStatus { get; set; }
        [JsonProperty(PropertyName = "back_status", NullValueHandling = NullValueHandling.Ignore)]
        public int BackStatus { get; set; }
        [JsonProperty(PropertyName = "company_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyCode { get; set; }
        [JsonProperty(PropertyName = "exception_info", NullValueHandling = NullValueHandling.Ignore)]
        public string ExceptionInfo { get; set; }
        [JsonProperty(PropertyName = "sc_id", NullValueHandling = NullValueHandling.Ignore)]
        public int ScId { get; set; }
        [JsonProperty(PropertyName = "label_status", NullValueHandling = NullValueHandling.Ignore)]
        public int LabelStatus { get; set; }
        [JsonProperty(PropertyName = "tracking_number", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackingNumber { get; set; }
        [JsonProperty(PropertyName = "transit_warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public int TransitWarehouseId { get; set; }
        [JsonProperty(PropertyName = "to_warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public int ToWarehouseId { get; set; }
        [JsonProperty(PropertyName = "sm_code", NullValueHandling = NullValueHandling.Ignore)]
        public string SmCode { get; set; }
        [JsonProperty(PropertyName = "fba_id", NullValueHandling = NullValueHandling.Ignore)]
        public int FbaId { get; set; }
        [JsonProperty(PropertyName = "warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public int WarehouseId { get; set; }
        [JsonProperty(PropertyName = "next_warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public int NextWarehouse_id { get; set; }
        [JsonProperty(PropertyName = "is_insurance", NullValueHandling = NullValueHandling.Ignore)]
        public int IsInsurance { get; set; }
        [JsonProperty(PropertyName = "insurance_value", NullValueHandling = NullValueHandling.Ignore)]
        public decimal InsuranceValue { get; set; }
        [JsonProperty(PropertyName = "box_total", NullValueHandling = NullValueHandling.Ignore)]
        public int box_total { get; set; }
        [JsonProperty(PropertyName = "product_total", NullValueHandling = NullValueHandling.Ignore)]
        public int ProductTotal { get; set; }
        [JsonProperty(PropertyName = "weight_total", NullValueHandling = NullValueHandling.Ignore)]
        public decimal WeightTotal { get; set; }
        [JsonProperty(PropertyName = "reckon_weight", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ReckonWeight { get; set; }
        [JsonProperty(PropertyName = "currency_amount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal CurrencyAmount { get; set; }
        [JsonProperty(PropertyName = "currency_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyCode { get; set; }
        [JsonProperty(PropertyName = "pay_status", NullValueHandling = NullValueHandling.Ignore)]
        public int PayStatus { get; set; }
        [JsonProperty(PropertyName = "pay_time", NullValueHandling = NullValueHandling.Ignore)]
        public string PayTime { get; set; }
        [JsonProperty(PropertyName = "fba_remarks", NullValueHandling = NullValueHandling.Ignore)]
        public string FbaRemarks { get; set; }
        [JsonProperty(PropertyName = "create_site", NullValueHandling = NullValueHandling.Ignore)]
        public int CreateSite { get; set; }
        [JsonProperty(PropertyName = "create_user_id", NullValueHandling = NullValueHandling.Ignore)]
        public int CreateUserId { get; set; }
        [JsonProperty(PropertyName = "create_time", NullValueHandling = NullValueHandling.Ignore)]
        public string CreateTime { get; set; }
        [JsonProperty(PropertyName = "update_user_id", NullValueHandling = NullValueHandling.Ignore)]
        public int UpdateUserId { get; set; }
        [JsonProperty(PropertyName = "update_time", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdateTime { get; set; }
        [JsonProperty(PropertyName = "transit_receipt_time", NullValueHandling = NullValueHandling.Ignore)]
        public string TransitReceiptTime { get; set; }
        [JsonProperty(PropertyName = "transit_send_time", NullValueHandling = NullValueHandling.Ignore)]
        public string TransitSendTime { get; set; }
        [JsonProperty(PropertyName = "to_receipt_time", NullValueHandling = NullValueHandling.Ignore)]
        public string ToReceiptTime { get; set; }
        [JsonProperty(PropertyName = "to_send_time", NullValueHandling = NullValueHandling.Ignore)]
        public string ToSendTime { get; set; }
        [JsonProperty(PropertyName = "sync_wms_status", NullValueHandling = NullValueHandling.Ignore)]
        public int SyncWmsStatus { get; set; }
        [JsonProperty(PropertyName = "sync_wms_time", NullValueHandling = NullValueHandling.Ignore)]
        public string SyncWmsTime { get; set; }
    }

    public class FbaBox
    {
        [JsonProperty(PropertyName = "oms_box", NullValueHandling = NullValueHandling.Ignore)]
        public List<OmsBox> OmsBox { get; set; }

        [JsonProperty(PropertyName = "transit_box", NullValueHandling = NullValueHandling.Ignore)]
        public List<TransitBox> TransitBox { get; set; }

        [JsonProperty(PropertyName = "final_box", NullValueHandling = NullValueHandling.Ignore)]
        public List<FinalBox> FinalBox { get; set; }
    }

    public class OmsBox
    {
        [JsonProperty(PropertyName = "box_code", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxCode { get; set; }
        [JsonProperty(PropertyName = "box_num", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxNum { get; set; }
        [JsonProperty(PropertyName = "box_length", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? BoxLength { get; set; }
        [JsonProperty(PropertyName = "box_width", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? BoxWidth { get; set; }
        [JsonProperty(PropertyName = "box_height", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? BoxHeight { get; set; }
        [JsonProperty(PropertyName = "box_weight", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? BoxWeight { get; set; }
        [JsonProperty(PropertyName = "product_qty", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ProductQty { get; set; }
    }

    public class FinalBox : TransitBox
    {
    }
    public class TransitBox
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }
        [JsonProperty(PropertyName = "warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? WarehouseId { get; set; }
        [JsonProperty(PropertyName = "box_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? BoxId { get; set; }
        [JsonProperty(PropertyName = "box_code", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxCode { get; set; }
        [JsonProperty(PropertyName = "fba_code", NullValueHandling = NullValueHandling.Ignore)]
        public string FbaCode { get; set; }
        [JsonProperty(PropertyName = "length", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Length { get; set; }
        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Width { get; set; }
        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Height { get; set; }
        [JsonProperty(PropertyName = "weight", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Weight { get; set; }
        [JsonProperty(PropertyName = "pro_qty", NullValueHandling = NullValueHandling.Ignore)]
        public int? ProQty { get; set; }
        [JsonProperty(PropertyName = "measure_user_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? MeasureUserId { get; set; }
        [JsonProperty(PropertyName = "measure_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? MeasureTime { get; set; }
        [JsonProperty(PropertyName = "arrive_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ArriveTime { get; set; }
        [JsonProperty(PropertyName = "out_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? OutTime { get; set; }
        [JsonProperty(PropertyName = "receipt_status", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReceiptStatus { get; set; }
        [JsonProperty(PropertyName = "measure_status", NullValueHandling = NullValueHandling.Ignore)]
        public int? MeasureStatus { get; set; }
        [JsonProperty(PropertyName = "exception_status", NullValueHandling = NullValueHandling.Ignore)]
        public int? ExceptionStatus { get; set; }
        [JsonProperty(PropertyName = "exception_confirm", NullValueHandling = NullValueHandling.Ignore)]
        public int? ExceptionConfirm { get; set; }
        [JsonProperty(PropertyName = "exception_info", NullValueHandling = NullValueHandling.Ignore)]
        public string ExceptionInfo { get; set; }
        [JsonProperty(PropertyName = "update_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdateTime { get; set; }
    }

    public class FbaBoxDetail
    {
        [JsonProperty(PropertyName = "box_detail_id", NullValueHandling = NullValueHandling.Ignore)]
        public int BoxDetailId { get; set; }
        [JsonProperty(PropertyName = "box_id", NullValueHandling = NullValueHandling.Ignore)]
        public int BoxId { get; set; }
        [JsonProperty(PropertyName = "box_code", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxCode { get; set; }
        [JsonProperty(PropertyName = "product_id", NullValueHandling = NullValueHandling.Ignore)]
        public int ProductId { get; set; }
        [JsonProperty(PropertyName = "product_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductBarcode { get; set; }
        [JsonProperty(PropertyName = "goods_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string GoodsBarcode { get; set; }
        [JsonProperty(PropertyName = "product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }
        [JsonProperty(PropertyName = "quantity", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Quantity { get; set; }
        [JsonProperty(PropertyName = "length", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Length { get; set; }
        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Width { get; set; }
        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Height { get; set; }
        [JsonProperty(PropertyName = "weight", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Weight { get; set; }
        [JsonProperty(PropertyName = "transit_qty", NullValueHandling = NullValueHandling.Ignore)]
        public decimal TransitQty { get; set; }
        [JsonProperty(PropertyName = "final_qty", NullValueHandling = NullValueHandling.Ignore)]
        public decimal FinalQty { get; set; }
    }

    public class FbaPackBox
    {
        [JsonProperty(PropertyName = "box_code", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxCode { get; set; }
        [JsonProperty(PropertyName = "box_num", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxNum { get; set; }
        [JsonProperty(PropertyName = "box_length", NullValueHandling = NullValueHandling.Ignore)]
        public object BoxLength { get; set; }
        [JsonProperty(PropertyName = "box_width", NullValueHandling = NullValueHandling.Ignore)]
        public object BoxWidth { get; set; }
        [JsonProperty(PropertyName = "box_height", NullValueHandling = NullValueHandling.Ignore)]
        public object BoxHeight { get; set; }
        [JsonProperty(PropertyName = "box_weight", NullValueHandling = NullValueHandling.Ignore)]
        public object BoxWeight { get; set; }
        [JsonProperty(PropertyName = "product_qty", NullValueHandling = NullValueHandling.Ignore)]
        public object ProductQty { get; set; }
        [JsonProperty(PropertyName = "tracking_number", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackingNumber { get; set; }
        [JsonProperty(PropertyName = "box_weight_charged", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxWeightCharged { get; set; }
    }

    public class FbaPackDetail
    {
        [JsonProperty(PropertyName = "pack_detail_id", NullValueHandling = NullValueHandling.Ignore)]
        public int PackDetailId { get; set; }
        [JsonProperty(PropertyName = "box_num", NullValueHandling = NullValueHandling.Ignore)]
        public int BoxNum { get; set; }
        [JsonProperty(PropertyName = "product_id", NullValueHandling = NullValueHandling.Ignore)]
        public int ProductId { get; set; }
        [JsonProperty(PropertyName = "product_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductBarcode { get; set; }
        [JsonProperty(PropertyName = "goods_barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string GoodsBarcode { get; set; }
        [JsonProperty(PropertyName = "product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }
        [JsonProperty(PropertyName = "quantity", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Quantity { get; set; }
        [JsonProperty(PropertyName = "length", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Length { get; set; }
        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Width { get; set; }
        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Height { get; set; }
        [JsonProperty(PropertyName = "weight", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Weight { get; set; }
    }

    public class FbaLog
    {
        [JsonProperty(PropertyName = "fba_code", NullValueHandling = NullValueHandling.Ignore)]
        public string FbaCode { get; set; }
        [JsonProperty(PropertyName = "box_code", NullValueHandling = NullValueHandling.Ignore)]
        public string BoxCode { get; set; }
        [JsonProperty(PropertyName = "warehouse_id", NullValueHandling = NullValueHandling.Ignore)]
        public int WarehouseId { get; set; }
        [JsonProperty(PropertyName = "operation_type", NullValueHandling = NullValueHandling.Ignore)]
        public int OperationType { get; set; }
        [JsonProperty(PropertyName = "status_from", NullValueHandling = NullValueHandling.Ignore)]
        public int StatusFrom { get; set; }
        [JsonProperty(PropertyName = "status_to", NullValueHandling = NullValueHandling.Ignore)]
        public int StatusTo { get; set; }
        [JsonProperty(PropertyName = "log_content", NullValueHandling = NullValueHandling.Ignore)]
        public string LogContent { get; set; }
        [JsonProperty(PropertyName = "client_sys", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientSys { get; set; }
        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Ignore)]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "user_name", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "operation_time", NullValueHandling = NullValueHandling.Ignore)]
        public string OperationTime { get; set; }
    }
}
