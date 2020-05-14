using System;
using System.Collections.Generic;
using System.Text;
using Xin.Common.CustomAttribute;

namespace Xin.Web.Framework.Model
{
   public class ProductImportModel
    {
        [Excel(Header = "产品名称")]

        public string sku { get; set; }

        [Excel(Header = "图片",Picture =true)]
        public string image { get; set; }

        [Excel(Header = "图片地址")]
        public string imageUrl { get; set; }
    }
}
