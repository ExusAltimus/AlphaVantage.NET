using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DataMemberNameAttribute : Attribute
    {
        public string Name { get; set; }
        public DataMemberNameAttribute(string name)
        {
            Name = name;
        }
    }
}
