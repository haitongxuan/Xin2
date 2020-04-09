using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xin.Common;
using Xin.Repository;
using Xin.Web.Framework.Model;

namespace Xin.Web.Framework.Helper
{
   public class DataBaseHelper<T> where T : class, new()
    {
        public static GridPage<List<T>> GetList(IUowProvider _uowProvider,GridPage<List<T>> res, DatetimePointPageReq pageReq, Func<IQueryable<T>, IQueryable<T>> includes = null)
        {
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<T>();

                    if (pageReq == null)
                    {
                        res.data = repository.GetPage(0, 50).ToList();
                        return res;
                    }
                    else
                    {
                        if (pageReq.pageSize == 0)
                        {
                            pageReq.pageSize = 50;
                        }
                        if (pageReq.pageNum == 0)
                        {
                            pageReq.pageNum = 1;
                        }
                    }
                    int startRow = (pageReq.pageNum - 1) * pageReq.pageSize;
                    Filter<T> filter = new Filter<T>(null);
                    if (pageReq.query.Count > 0)
                    {
                        var fuc = FilterHelper<T>.GetExpression(pageReq.query, "common");
                        filter = new Filter<T>(fuc);
                    }
                    OrderBy<T> orderBy = new OrderBy<T>(null);
                    if (pageReq.order != null)
                    {
                        orderBy = new OrderBy<T>(pageReq.order.columnName, pageReq.order.reverse);
                    }
                    res.totalCount = repository.Query(filter.Expression, orderBy.Expression).Count();
                    res.data = repository.QueryPage(startRow, pageReq.pageSize, filter.Expression, orderBy.Expression, includes).ToList();
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }
    }
}
