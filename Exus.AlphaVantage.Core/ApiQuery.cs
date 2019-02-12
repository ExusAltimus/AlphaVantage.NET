using Exus.AlphaVantage.Core.Attributes;
using Exus.AlphaVantage.Core.Helpers;
using Exus.AlphaVantage.Core.Queries.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Exus.AlphaVantage.Core
{
    public class ApiQuery<TApiQueryResult> : IApiQuery<TApiQueryResult>
    {
        public Dictionary<string, string> Parameters { get; set; }

        public ApiQuery()
        {
            this.Parameters = new Dictionary<string, string>();
        }

        public ApiQuery(ApiFunction function) : this()
        {
            this.Function = function;
        }

        public ApiQuery(Dictionary<string, string> parameters)
        {
            this.Parameters = parameters;
        }

        public ApiQuery(ApiFunction function, Dictionary<string, string> parameters) : this(parameters)
        {
            this.Function = function;
        }

        /// <summary>
        /// Used by properties that are decorated with the ApiParameter attribute
        /// </summary>
        protected void SetParameter(object value)
        {
            var caller = new StackFrame(1);
            var method = caller.GetMethod();
            var propName = method.Name.Substring(4);
            var type = method.ReflectedType;
            var pi = type.GetProperty(propName);
            object[] attributes = pi.GetCustomAttributes(typeof(ApiParameterAttribute), true);
            if (attributes != null && attributes.Length == 1)
            {
                var ssAttr = attributes[0] as ApiParameterAttribute;
                if (pi.PropertyType.IsEnum)
                {
                    var converter = new ApiEnumTypeConverter(pi.PropertyType);
                    Parameters[ssAttr.Name] = (string)converter.ConvertTo(value, typeof(string));
                }
                else
                {
                    Parameters[ssAttr.Name] = value.ToString();
                }
            }
            else
            {
                throw new Exception("Property must have an ApiParameter attribute");
            }
        }

        /// <summary>
        /// Used by properties that are decorated with the ApiParameter attribute
        /// </summary>
        protected dynamic GetParameter()
        {
            var caller = new StackFrame(1);
            var method = caller.GetMethod();
            var propName = method.Name.Substring(4);
            var type = method.ReflectedType;
            var pi = type.GetProperty(propName);
            object[] attributes = pi.GetCustomAttributes(typeof(ApiParameterAttribute), true);
            if (attributes != null && attributes.Length == 1)
            {
                var ssAttr = attributes[0] as ApiParameterAttribute;
                if (Parameters.ContainsKey(ssAttr.Name))
                {
                    if (pi.PropertyType.IsEnum)
                    {
                        var converter = new ApiEnumTypeConverter(pi.PropertyType);
                        return converter.ConvertFrom(Parameters[ssAttr.Name]);
                    }
                    else
                    {
                        return Parameters[ssAttr.Name];
                    }             
                }
            }
            else
            {
                throw new Exception("Property must have an ApiParameter attribute");
            }
            return default(dynamic);
        }

        public void SetParameter(string parameterName, string value)
        {
            this.Parameters.TryAdd(parameterName, value);
        }

        public string GetParameter(string parameterName)
        {
            return this.Parameters.GetValueOrDefault(parameterName);
        }

        public bool HasParameter(string parameterName)
        {
            return this.Parameters.ContainsKey(parameterName);
        }

        [ApiParameter("apikey")]
        public string ApiKey
        {
            get { return GetParameter(); }
            set { SetParameter(value); }
        }

        [ApiParameter("function")]
        public ApiFunction Function
        {
            get { return GetParameter(); }
            set { SetParameter(value); }
        }
    }


}
