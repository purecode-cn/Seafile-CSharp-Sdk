using System;
namespace SeafileClient.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal class DestructureAttribute:Attribute
    {
        public string Key { get; set; }
        public DestructureAttribute(string key)
        {
            Key = key;
        }
    }
}
