//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//	   生成时间 2020-02-05 09:46:35
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失
//     作者：Justable
// </auto-generated>
//------------------------------------------------------------------------------

using Newtonsoft.Json;
using System;

namespace Xin.ExternalService.EC.Response.Model
{
    public partial class EC_SubProducts
    {
        /// <summary>
        /// 组合子产品SKU
        /// </summary>
        [JsonProperty(PropertyName = "pcrProductSku")]
        public string PcrProductSku { get; set; }
        /// <summary>
        /// 组合子产品数量
        /// </summary>
        [JsonProperty(PropertyName = "pcrQty")]
        public int? PcrQty { get; set; }
    }
}

