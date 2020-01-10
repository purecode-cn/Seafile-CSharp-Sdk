using System;
namespace SeafileClient.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter|AttributeTargets.Method, AllowMultiple = true)]
    internal class ForQueryStringAttribute:Attribute
    {
        public string Name { get; set; }
        public bool IgnoreIfDefault { get; set; } = true;
        public object Value { get; set; }
        public Type ConverterType { get; set; }

        public ForQueryStringAttribute()
        {

        }

        public ForQueryStringAttribute(string name)
        {
            Name = name;
        }
        public ForQueryStringAttribute(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
