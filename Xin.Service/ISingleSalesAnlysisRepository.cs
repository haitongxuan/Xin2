using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities.VirtualEntity;
using Xin.Repository;
namespace Xin.Service
{
    public interface ISingleSalesAnlysisRepository
    {
        IEnumerable<SingleSalesAnalysis> GetList(DateTime filterdate, string filterStr = null);

        DataPage<SingleSalesAnalysis> GetPage(DateTime filterdate, int pageIndex, int pageSize, string filterStr = null);
    }
}
