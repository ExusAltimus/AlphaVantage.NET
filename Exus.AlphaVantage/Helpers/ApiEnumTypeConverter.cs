using Exus.AlphaVantage.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Exus.AlphaVantage.Helpers
{
    public class ApiEnumTypeConverter : TypeConverter
    {
        private Dictionary<object, string> _enumMap;
        private Type _enumType;

        public ApiEnumTypeConverter(Type enumType)
        {
            BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.GetField
                | BindingFlags.Public;

            _enumType = enumType;
            _enumMap = enumType.GetFields(bindingFlags).ToDictionary(
                k => k.GetValue(enumType),
                v => GetEnumName(v)
                );
        }


        private static string GetEnumName(FieldInfo field)
        {
            ApiEnumAttribute attr = field.GetCustomAttribute<ApiEnumAttribute>();
            return (attr != null) ? attr.Name : field.Name;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string stringValue = value as string;

            if (stringValue != null)
            {
                var first = _enumMap.FirstOrDefault((kvp) => kvp.Value == stringValue);
                if (!Object.ReferenceEquals(first, null))
                {
                    return first.Key;
                }
                else
                {
                    throw new ArgumentException("Cannot convert '" + stringValue + "' to " + _enumType.Name);
                }
            }
            throw new ArgumentException("Cannot convert '" + stringValue + "' to " + _enumType.Name);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
           CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string)) { return _enumMap[value]; }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
