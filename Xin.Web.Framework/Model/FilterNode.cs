using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Web.Framework.Model
{
    public class FilterNode
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

        public override string ToString()
        {
            string res = string.Empty;
            string opt = Operate.GetSqlOperate(binaryop);
            switch (binaryop)
            {
                case (Operate.like):
                    res = $" {andorop} {key} {opt} '%{value.ToString()}%' ";
                    break;
                case (Operate.include):
                    res = $" {andorop} {key} {opt} ({value.ToString()})  ";
                    break;
                case (Operate.between):
                    string[] betweenpair = value.ToString().Split(',');
                    res = $"{andorop} {key} {opt} '{betweenpair[0]}' and '{betweenpair[1]}' ";
                    break;
                default:
                    res = $" {andorop} {key} {opt} '{value.ToString()}'";
                    break;
            }
            return res;
        }

        public static string ListToString(List<FilterNode> filterNodes)
        {
            string res = string.Empty;
            foreach (var item in filterNodes)
            {
                res = res + item.ToString();
            }
            return res;
        }
    }

    public class Operate
    {
        public const string eq = "eq";
        public const string neq = "neq";
        public const string gt = "gt";
        public const string lt = "lt";
        public const string gte = "gte";
        public const string lte = "lte";
        public const string like = "like";
        public const string include = "in";
        public const string between = "between";

        public static string GetSqlOperate(string operate)
        {
            string res = string.Empty;
            switch (operate)
            {
                case (eq):
                    res = "=";
                    break;
                case (neq):
                    res = "<>";
                    break;
                case (gt):
                    res = ">";
                    break;
                case (lt):
                    res = "<";
                    break;
                case (gte):
                    res = ">=";
                    break;
                case (lte):
                    res = "<=";
                    break;
                case (like):
                    res = "like";
                    break;
                case (include):
                    res = "in";
                    break;
                case (between):
                    res = "between";
                    break;
                default:
                    break;
            }
            return res;
        }
    }
}
