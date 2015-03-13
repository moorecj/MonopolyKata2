using System;

namespace Monopoly.Core.Extensions
{
    public static class TypeExtensions
    {
        public static bool HasAttribute(this Type type, Type attributeType)
        {
            return type.GetCustomAttributes(attributeType, true).Length > 0;
        }
    }
}