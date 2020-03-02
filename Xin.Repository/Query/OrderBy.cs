using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Xin.Repository
{
    /// <summary>
    /// 创建orderby表达式
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class OrderBy<TEntity>
    {
        public OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> expression)
        {
            Expression = expression;
        }

        public OrderBy(string columName, bool reverse)
        {
            Expression = GetOrderBy(columName, reverse);
        }

        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> Expression { get; private set; }


        private Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> GetOrderBy(string columnName, bool reverse)
        {
            Type typeQueryable = typeof(IQueryable<TEntity>);
            ParameterExpression argQueryable = System.Linq.Expressions.Expression.Parameter(typeQueryable, "p");
            var outerExpression = System.Linq.Expressions.Expression.Lambda(argQueryable, argQueryable);

            IQueryable<TEntity> query = new List<TEntity>().AsQueryable<TEntity>();
            var entityType = typeof(TEntity);
            ParameterExpression arg = System.Linq.Expressions.Expression.Parameter(entityType, "x");

            Expression expression = arg;
            string[] properties = columnName.Split(',');
            foreach (string propertyName in properties)
            {
                string propertyNameTitle = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(propertyName);
                PropertyInfo propertyInfo = entityType.GetProperty(propertyNameTitle,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                expression = System.Linq.Expressions.Expression.Property(expression, propertyInfo);
                entityType = propertyInfo.PropertyType;
            }
            LambdaExpression lambda = System.Linq.Expressions.Expression.Lambda(expression, arg);
            string methodName = reverse ? "OrderByDescending" : "OrderBy";

            MethodCallExpression resultExp = System.Linq.Expressions.Expression.Call(typeof(Queryable),
                                                                                     methodName,
                                                                                     new Type[] { typeof(TEntity), entityType },
                                                                                     outerExpression.Body,
                                                                                     System.Linq.Expressions.Expression.Quote(lambda));

            var finalLambda = System.Linq.Expressions.Expression.Lambda(resultExp, argQueryable);
            

            return (Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>)finalLambda.Compile();
        }
    }
}