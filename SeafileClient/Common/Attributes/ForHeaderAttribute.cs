using System;
namespace SeafileClient.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    internal class ForHeaderAttribute:Attribute
    {
    }
}
