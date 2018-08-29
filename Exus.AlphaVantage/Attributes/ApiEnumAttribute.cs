using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ApiEnumAttribute : Attribute
    {
        public string Name { get; set; }
        public ApiEnumAttribute(string name)
        {
            Name = name;
        }
    }
}
