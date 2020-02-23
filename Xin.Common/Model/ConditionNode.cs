using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Common.Model
{
    public class ConditionNode
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 二元运算符
        /// </summary>
        public string binaryop { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public object value { get; set; }
        /// <summary>
        /// 条件运算符
        /// </summary>
        public string andorop { get; set; }
    }

    public class Operate
    {
        public string eq = "eq";
        public string neq = "neq";
        public string gt = "gt";
        public string lt = "lt";
        public string gte = "gte";
        public string lte = "lte";
        public string like = "like";
        public string include = "in";
        public string between = "between";
    }
}
