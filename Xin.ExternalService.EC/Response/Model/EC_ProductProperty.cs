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
    public partial class EC_ProductProperty
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        [JsonProperty(PropertyName = "attrName")]
        public string AttrName { get; set; }
        /// <summary>
        /// 属性英文名称
        /// </summary>

        [JsonProperty(PropertyName = "attrNameEn")]
        public string AttrNameEn { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>

        [JsonProperty(PropertyName = "attrValue")]
        public decimal? AttrValue { get; set; }

    }
}

