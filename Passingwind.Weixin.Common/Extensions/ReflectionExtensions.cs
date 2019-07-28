using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Passingwind.Weixin.Extensions
{
    public static class ReflectionExtensions
    {
        private static Dictionary<string, PropertyInfo[]> _typeProperties = new Dictionary<string, PropertyInfo[]>();

        public static PropertyInfo[] GetProperties(this Type type, bool useCache = true)
        {
            if (useCache && _typeProperties.ContainsKey(type.FullName))
            {
                return _typeProperties[type.FullName];
            }
            else
            {
                var properties = type.GetProperties();

                _typeProperties[type.FullName] = properties;

                return properties;
            }
        }
    }
}
