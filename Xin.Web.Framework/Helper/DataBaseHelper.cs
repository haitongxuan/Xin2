﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Xin.Common;
using Xin.Entities;
using Xin.Repository;
using Xin.Web.Framework.Model;

namespace Xin.Web.Framework.Helper
{
    public class DataBaseHelper<T> where T : class, new()
    {
        public static GridPage<List<T>> GetList(IUowProvider _uowProvider, GridPage<List<T>> res, DatetimePointPageReq pageReq, Func<IQueryable<T>, IQueryable<T>> includes = null,bool getAll = false)
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
                    if (getAll)
                    {
                        res.data = repository.Query(filter.Expression, orderBy.Expression).ToList();
                    }
                    else
                    {
                        res.data = repository.QueryPage(startRow, pageReq.pageSize, filter.Expression, orderBy.Expression, includes).ToList();
                    }
                    res.totalCount = repository.Query(filter.Expression, orderBy.Expression).Count();
                    
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }

        public static GridPage<List<T>> GetFromProcedure(IUowProvider _uowProvider, GridPage<List<T>> res, DatetimePointPageReq pageReq, bool getAll, string procedure, params SqlParameter[] sqlParameters)
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
                    var resAll = repository.FromProcedure(procedure, sqlParameters);
                    if (pageReq.query.Count > 0)
                    {
                        var fuc = FilterHelper<T>.GetExpression(pageReq.query, "commonProcedure");
                        resAll = resAll.Where(fuc);
                    }
                    OrderBy<T> orderBy = new OrderBy<T>(null);
                    if (pageReq.order != null)
                    {
                        orderBy = new OrderBy<T>(pageReq.order.columnName, pageReq.order.reverse);
                        resAll = orderBy.Expression(resAll);
                    }
                    res.data = resAll.ToList();
                    res.totalCount = res.data.Count();
                    if (!getAll)
                    {
                        res.data = res.data.Skip((pageReq.pageNum - 1) * pageReq.pageSize).Take(pageReq.pageSize).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }

        public static GridPage<T> Get(IUowProvider _uowProvider, GridPage<T> res, object classifyId, Func<IQueryable<T>, IQueryable<T>> includes = null)
        {
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<T>();
                    res.data = repository.Get(classifyId, includes);
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }

        public static GridPage<T> Create(IUowProvider _uowProvider, T newsDetail, GridPage<T> res, bool v)
        {
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<T>();
                    repository.Attach(newsDetail);
                    uow.SaveChanges();
                    res.data = newsDetail;
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }

        public static GridPage<T> Delete(IUowProvider _uowProvider, object id, GridPage<T> res)
        {
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<T>();
                    var menu = repository.Get(id);
                    if (menu != null)
                    {
                        repository.Remove(menu);
                        uow.SaveChanges();
                        res.data = null;
                        res.msg = "删除成功";
                    }
                    else
                    {
                        res.code = ResCode.NotFound;
                        res.data = null;
                        res.msg = "未找到该记录";
                    }
                }
            }
            catch (Exception ex)
            {
                res.code = ResCode.ServerError;
                res.msg = ex.Message;
            }
            return res;
        }
        public static GridPage<T> Edit(IUowProvider _uowProvider, T newsDetail, GridPage<T> res)
        {
            try
            {
                using (var uow = _uowProvider.CreateUnitOfWork())
                {
                    var repository = uow.GetRepository<T>();
                    repository.Update(newsDetail);
                    uow.SaveChanges();
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
