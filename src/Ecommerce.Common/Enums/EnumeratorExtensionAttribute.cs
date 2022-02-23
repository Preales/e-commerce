using System;
using System.Collections;

namespace Ecommerce.Common.Enums
{
    public class EnumeratorExtensionAttribute : Attribute
    {
        public EnumeratorExtensionAttribute(string value)
        {
            Value = value;
        }
        public string Value { get; }
    }

    public static class EnumeratorExtension
    {
        public static string ToStringAttribute(this Enum value)
        {
            var stringValues = new Hashtable();

            string output = null;
            var type = value.GetType();

            //Comprueba si ya existe la búsqueda en caché
            if (stringValues.ContainsKey(value))
            {
                var stringValueAttribute = (EnumeratorExtensionAttribute)stringValues[value];
                if (stringValueAttribute != null)
                    output = stringValueAttribute.Value;
            }
            else
            {
                //Buscar el ToStringAttribute en los atributos personalizados
                System.Reflection.FieldInfo fi = type.GetField(value.ToString());
                var attrs = (EnumeratorExtensionAttribute[])fi.GetCustomAttributes(typeof(EnumeratorExtensionAttribute), false);
                if (attrs.Length <= 0) return null;

                stringValues.Add(value, attrs[0]);
                output = attrs[0].Value;
            }
            return output;
        }
    }
}