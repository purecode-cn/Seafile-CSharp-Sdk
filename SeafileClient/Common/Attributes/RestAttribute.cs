using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SeafileClient.Common.Attributes
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal class RestAttribute : Attribute
    {
        public Method Method { get; private set; }
        public string Template { get; private set; }

        public bool IsAbsoluteUrl { get; set; } = false;

        public RestAttribute(Method method, string template)
        {
            Method = method;
            Template = template;
        }
    }

    internal class PostAttribute : RestAttribute
    {
        public PostAttribute(string template) : base(Method.POST, template) { }
    }

    internal class GetAttribute : RestAttribute
    {
        public GetAttribute(string template) : base(Method.GET, template) { }
    }

    internal class PutAttribute : RestAttribute
    {
        public PutAttribute(string template) : base(Method.PUT, template) { }
    }

    internal class DeleteAttribute : RestAttribute
    {
        public DeleteAttribute(string template) : base(Method.DELETE, template) { }
    }
}
