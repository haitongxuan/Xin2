using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xin.Web.Framework.Model;
using Xin.Repository;

namespace Xin.Web.Framework.Helper
{
    public class PageMapper<T> where T : class, new()
    {
        public static PageDateRes<T> ToPageDateRes(DataPage<T> dpage)
        {
            PageDateRes<T> page = new PageDateRes<T>();
            if (dpage.Data.Any())
            {
                page.data = dpage.Data.ToList();
                page.count = dpage.TotalEntityCount;
                page.code = ResCode.Success;
                page.PageNum = dpage.PageNumber;
                page.PageSize = dpage.PageLength;
                page.totalPage = dpage.TotalPageCount;

            }
            else
            {
                page.code = ResCode.Success;
                page.msg = "没有数据可供使用";
            }
            return page;
        }
    }
}
