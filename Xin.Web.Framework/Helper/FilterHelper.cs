﻿using System;
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
            var query = ParseExpressionBody(conditions, parameter);
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
            Expression key = Expression.Property(parameter, condition.key);
            Expression value = Expression.Constant(condition.value);
            try
            {
                switch (condition.binaryop)
                {
                    case "like":
                        return Expression.Call(key, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), value);
                    case "eq":
                        return Expression.Equal(key, Expression.Convert(value, key.Type));
                    case "gt":
                        return Expression.GreaterThan(key, Expression.Convert(value, key.Type));
                    case "gte":
                        return Expression.GreaterThanOrEqual(key, Expression.Convert(value, key.Type));
                    case "lt":
                        return Expression.LessThan(key, Expression.Convert(value, key.Type));
                    case "lte":
                        return Expression.LessThanOrEqual(key, Expression.Convert(value, key.Type));
                    case "neq":
                        return Expression.NotEqual(key, Expression.Convert(value, key.Type));
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