using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Xin.Web.Framework.Model
{
    public class DataRes<T>
    {
        [Description("e.g. 200:success; 500:system error; 404:not found; 401:Unauthorized ")]
        public ResCode code { get; set; } = ResCode.Success;

        public string msg { get; set; } = "成功";

        public T data { get; set; }
    }

    public enum ResCode
    {
        /// <summary>
        /// 错误
        /// </summary>
        Error = -1,
        /// <summary>
        /// 验证未通过
        /// </summary>
        NoValidate = 0,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 200,
        /// <summary>
        /// 未发现
        /// </summary>
        NotFound=404,
        /// <summary>
        /// 服务器内部错误
        /// </summary>
        ServerError=500,
        /// <summary>
        /// 未授权
        /// </summary>
        Unauthorized=401
    }
}
