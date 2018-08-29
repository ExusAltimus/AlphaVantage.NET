using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ApiParameterAttribute : Attribute
    {
        public string Name { get; set; }
        public ApiParameterAttribute(string name)
        {
            Name = name;
        }
    }
}
