using System;

namespace Xin.Common.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoCodeAttribute : Attribute
    {
        public string FixHeader { get; set; }
        public int Length { get; set; }
        public bool AutoCode { get; set; } = false;
        public string AutoCodePropertyName { get; set; } = null;

        public AutoCodeAttribute(string fixheader, int length, bool autoCode = false, string autoCodePropertyName = null)
        {
            FixHeader = fixheader;
            Length = length;
            AutoCode = autoCode;
            AutoCodePropertyName = autoCodePropertyName;
        }
    }
}
