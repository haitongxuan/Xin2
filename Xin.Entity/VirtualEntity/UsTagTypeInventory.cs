using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Entities.VirtualEntity
{
    /// <summary>
    /// 海外仓标签分类产品库存
    /// </summary>
    public class UsTagTypeInventory
    {
        public string ProductSku { get; set; }
        public string TagType { get; set; }
        public int Qty { get; set; }

        public int RowNumber { get; set; }
    }
}
