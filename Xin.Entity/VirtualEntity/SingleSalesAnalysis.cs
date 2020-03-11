using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Entities.VirtualEntity
{
    public class SingleSalesAnalysis
    {
        public long RowNumber { get; set; }
        public string WarehouseId { get; set; }
        public string WarehouseDesc { get; set; }
        public string SingleSku { get; set; }
        /// <summary>
        /// 最近三天销量
        /// </summary>
        public int ThreeDaysSales { get; set; } = 0;
        /// <summary>
        /// 最近七天销量
        /// </summary>
        public int SevenDaysSales { get; set; } = 0;
        /// <summary>
        /// 最近14天销量
        /// </summary>
        public int ForteenDaysSales { get; set; } = 0;
        /// <summary>
        /// 最近30天销量
        /// </summary>
        public int ThirtyDaysSales { get; set; } = 0;
    }
}
