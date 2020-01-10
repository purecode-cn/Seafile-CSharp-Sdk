using System;
namespace SeafileClient.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
    internal class ForParameterAttribute : Attribute
    {
        public string Name { get; set; } = null;
        public bool IgnoreIfDefault { get; set; } = true;
        public bool IsFile { get; set; } = false;

        public string Value { get; set; } = null;

        public Type ConverterType { get; set; }

        public ForParameterAttribute() { }
        public ForParameterAttribute(string name)
        {
            Name = name;
        }
        public ForParameterAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
