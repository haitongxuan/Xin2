using System;

namespace Xin.Common.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoCodeAttribute : Attribute
    {
        public string FixHeader { get; set; }
        public int Length { get; set; }

        public AutoCodeAttribute(string fixheader, int length)
        {
            FixHeader = fixheader;
            Length = length;
        }
    }
}
