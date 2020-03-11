using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities.VirtualEntity;

namespace Xin.Service
{
    public interface ISingleSalesAnlysisRepository
    {
        IEnumerable<SingleSalesAnalysis> GetList(DateTime filterdate, string filterStr = null);

        IEnumerable<SingleSalesAnalysis> GetPage(DateTime filterdate, int pageIndex, int pageSize, string filterStr = null);
    }
}
