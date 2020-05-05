using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Common.CustomAttribute
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true)]
    public class ExcelAttribute : Attribute
    {
        private string header;
        private string dateTime;
        private bool picture;
        public string Header
        {
            get { return header; }
            set { header = value; }
        }
        public bool Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
    }
}
