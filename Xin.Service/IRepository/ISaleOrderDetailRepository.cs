using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities.VirtualEntity;

namespace Xin.Service
{
   public interface ISaleOrderDetailRepository
    {
        IEnumerable<SaleOrderDetail> GetList(string startTime = null, string endTime = null);
  
    }
}
