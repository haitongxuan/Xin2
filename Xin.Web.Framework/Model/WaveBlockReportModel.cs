using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Web.Framework.Model
{
   public class WaveBlockReportModel
    {
        /// <summary>
        /// 尺寸
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        ///  尺寸总数量
        /// </summary>
        public int SizeTotal { get; set; }
        /// <summary>
        /// 尺寸总数/总数量
        /// </summary>
        public string SizeTotalRatio { get; set; }
        /// <summary>
        /// 速卖通销量
        /// </summary>
        public int aliSizeTotal { get; set; }
        /// <summary>
        /// 速卖通销量占比
        /// </summary>
        public string aliSizeTotalRatio { get; set; }

        /// <summary>
        /// 亚马逊销量
        /// </summary>
        public int amazSizeTotal { get; set; }
        /// <summary>
        /// 亚马逊销量占比
        /// </summary>
        public string amazSizeTotalRatio { get; set; }

        /// <summary>
        /// 自营站销量
        /// </summary>
        public int magentoSizeTotal { get; set; }
        /// <summary>
        /// 自营站销量占比
        /// </summary>
        public string magentoSizeTotalRatio { get; set; }

        /// <summary>
        /// SHOPIFY销量
        /// </summary>
        public int shopifySizeTotal { get; set; }
        /// <summary>
        /// SHOPIFY销量占比
        /// </summary>
        public string shopifySizeTotalRatio { get; set; }

        /// <summary>
        /// ebay销量
        /// </summary>
        public int ebaySizeTotal { get; set; }
        /// <summary>
        /// ebay销量占比
        /// </summary>
        public string ebaySizeTotalRatio { get; set; }
    }
}
