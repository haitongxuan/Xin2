using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Entities.VirtualEntity
{
    public class WavingBlock
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public int Magento { get; set; }
        public int Shopify { get; set; }
        public int Amazon { get; set; }
        public int Aliexpress { get; set; }
        public int Ebay { get; set; }

        public decimal MagentoTotalRatio { get; set; }
        public decimal ShopifyTotalRatio { get; set; }
        public decimal AmazonTotalRatio { get; set; }
        public decimal AliexpressTotalRatio { get; set; }
        public decimal EbayTotalRatio { get; set; }

    }
}
