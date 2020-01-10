using System;
namespace SeafileClient.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    internal class ForUrlSegmentAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
