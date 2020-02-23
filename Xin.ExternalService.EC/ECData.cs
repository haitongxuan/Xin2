using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xin.ExternalService.EC
{
    /// <summary>
    /// 易仓服务返回数据
    /// </summary>
    public class ECResponseBody
    {
        /// <summary>
        /// 状态码，表示请求结果状态
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 响应时间，比如：2016-11-22 15:30:57
        /// </summary>
        public string ResponseTime { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 请求接口名
        /// </summary>
        public string Service { get; set; }
        /// <summary>
        /// 返回数据集，根据具体接口，定义不同
        /// </summary>
        [JsonProperty(ItemIsReference = true)]
        public string Data { get; set; }
        /// <summary>
        /// 错误提示集Response.response.error，根据具体接口，定义不同
        /// </summary>
        public List<ECError> Error { get; set; }
        /// <summary>
        /// 查询接口返回，表示查询条件对应的结果集中的数据总条数
        /// </summary>
        public string TotalCount { get; set; }
        /// <summary>
        /// 查询接口返回，表示当前页数
        /// </summary>
        public string Page { get; set; }
        /// <summary>
        /// 查询接口返回，表示每页数量
        /// </summary>
        public string PageSize { get; set; }
    }
    /// <summary>
    /// Response.response.error
    /// </summary>
    public class ECError
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// 错误提示
        /// </summary>
        public string ErrorMsg { get; set; }

        public string ToString()
        {            
            return $"{ErrorCode}:{ErrorMsg}";
        }
    }
    /// <summary>
    /// 易仓接口异常
    /// </summary>
    public class ECExceptoin : Exception
    {
        public ECExceptoin(string message, List<ECError> errors) : base(message)
        {
            this.Errors = errors;
        }
        public List<ECError> Errors { get; set; }
    }
}
