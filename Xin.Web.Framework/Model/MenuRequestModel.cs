using System;
using System.Collections.Generic;
using System.Text;
using Xin.Entities;

namespace Xin.Web.Framework.Model
{
   public class MenuRequestModel:ResMenu
    {
        public int? parentId { get; set; }
        public string path { get; set; }
    }
}
