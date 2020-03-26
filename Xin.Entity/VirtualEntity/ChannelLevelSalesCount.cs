using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Entities.VirtualEntity
{
    public class ChannelLevelSalesCount
    {
        public string Channel { get; set; }
        public string Level { get; set; }
        public int SalesCountQty { get; set; }
        public long RowNumber { get; set; }
    }
}
