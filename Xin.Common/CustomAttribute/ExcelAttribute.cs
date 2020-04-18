using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Common.CustomAttribute
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true)]
    public class ExcelAttribute:Attribute
    {
        private string header;
        public string Header
        {
            get { return header; }
            set { header = value; }
        }
    }
}
