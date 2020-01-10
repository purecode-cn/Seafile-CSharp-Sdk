using System;
using System.Collections.Generic;
using System.Text;

namespace SeafileClient.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class RequestHeaderAttribute:Attribute
    {
        public string Key { get; private set; }
        public string ValueTemplate { get; private set; }
        public RequestHeaderAttribute(string key, string valueTemplate)
        {
            Key = key;
            ValueTemplate = valueTemplate;
        }
    }
}
