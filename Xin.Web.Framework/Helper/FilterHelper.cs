using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Xin.Web.Framework.Model;

namespace Xin.Common
{
    public class FilterHelper<T> where T : class
    {
        /// <summary>
        /// 动态获取查询表达式
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetExpression(IEnumerable<FilterNode> conditions, string name)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), name);
            List<FilterNode> lst = new List<FilterNode>();
            foreach (var item in conditions)
            {
                if (item.value==null)
                {
                    lst.Add(item);
                }
            }
            var query = ParseExpressionBody(lst, parameter);
            return Expression.Lambda<Func<T, bool>>(query, parameter);
        }

        private static Expression ParseExpressionBody(IEnumerable<FilterNode> conditions, ParameterExpression parameter)
        {
            if (conditions == null || conditions.Count() == 0)
            {
                return Expression.Constant(true, typeof(bool));
            }
            else if (conditions.Count() == 1)
            {
                return ParseCondition(conditions.First(), parameter);
            }
            else
            {
                var first = conditions.First();
                var rest = conditions.Skip(1);
                var next = rest.First();
                Expression left = ParseCondition(first, parameter);
                Expression right = ParseExpressionBody(rest, parameter);
                if (next.andorop == "and")
                    return Expression.And(left, right);
                else
                    return Expression.Or(left, right);
            }
        }

        private static Expression ParseCondition(FilterNode condition, ParameterExpression parameter)
        {
            var par = condition.key.Split(".");
            Expression key = Expression.Property(parameter, par[0]);
            for (int i = 1; i < par.Count(); i++)
            {
                key = Expression.Property(key, par[1]);
            }

            Expression value = null;
            if (key.Type == typeof(Int32) || key.Type == typeof(Int32?))
            {
                var value1 = condition.value.ToString().Replace(".0", "");
                int val = Convert.ToInt32(value1);
                value = Expression.Constant(val, key.Type);
            }
            else if (key.Type == typeof(Decimal) || key.Type == typeof(Decimal?))
            {
                Decimal val = Convert.ToDecimal(condition.value);
                value = Expression.Constant(val, key.Type);
            }
            else if (key.Type == typeof(Byte) || key.Type == typeof(Byte?))
            {
                Byte val = Convert.ToByte(condition.value);
                value = Expression.Constant(val, key.Type);
            }
            else if (key.Type == typeof(Boolean) || key.Type == typeof(Boolean?))
            {
                Boolean val = Convert.ToBoolean(condition.value);
                value = Expression.Constant(val, key.Type);
            }
            else if (key.Type == typeof(DateTime) || key.Type == typeof(DateTime?))
            {
                DateTime val = Convert.ToDateTime(condition.value);
                value = Expression.Constant(val, key.Type);
            }
            else
            {
                value = Expression.Constant(condition.value, key.Type);
            }

            try
            {
                switch (condition.binaryop)
                {
                    case "like":
                        return Expression.Call(key, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), value);
                    case "eq":
                        return Expression.Equal(key, value);
                    case "gt":
                        return Expression.GreaterThan(key, value);
                    case "gte":
                        return Expression.GreaterThanOrEqual(key, value);
                    case "lt":
                        return Expression.LessThan(key, value);
                    case "lte":
                        return Expression.LessThanOrEqual(key, value);
                    case "neq":
                        return Expression.NotEqual(key, value);
                    case "in":
                        return ParaseIn(parameter, condition);
                    case "between":
                        return ParaseBetween(parameter, condition);
                    default:
                        throw new NotImplementedException("不支持此操作");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Expression ParaseBetween(ParameterExpression parameter, FilterNode conditions)
        {
            ParameterExpression p = parameter;
            Expression key = Expression.Property(p, conditions.key);
            var valueArr = conditions.value.ToString().Split(',');
            if (valueArr.Length != 2)
            {
                throw new NotImplementedException("ParaseBetween参数错误");
            }
            try
            {
                int.Parse(valueArr[0]);
                int.Parse(valueArr[1]);
            }
            catch
            {
                throw new NotImplementedException("ParaseBetween参数只能为数字");
            }
            Expression expression = Expression.Constant(true, typeof(bool));
            //开始位置
            Expression startvalue = Expression.Constant(int.Parse(valueArr[0]));
            Expression start = Expression.GreaterThanOrEqual(key, Expression.Convert(startvalue, key.Type));

            Expression endvalue = Expression.Constant(int.Parse(valueArr[1]));
            Expression end = Expression.GreaterThanOrEqual(key, Expression.Convert(endvalue, key.Type));
            return Expression.AndAlso(start, end);
        }
        private static Expression ParaseIn(ParameterExpression parameter, FilterNode conditions)
        {
            ParameterExpression p = parameter;
            Expression key = Expression.Property(p, conditions.key);
            var valueArr = conditions.value.ToString().Split(',');
            Expression expression = Expression.Constant(true, typeof(bool));
            foreach (var itemVal in valueArr)
            {
                Expression value = Expression.Constant(itemVal);
                Expression right = Expression.Equal(key, Expression.Convert(value, key.Type));

                expression = Expression.Or(expression, right);
            }
            return expression;
        }
    }
}
