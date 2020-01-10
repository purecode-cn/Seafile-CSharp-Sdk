using System;
using System.Collections.Generic;
using System.Text;

namespace SeafileClient.Common.Attributes
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    internal class ResponseErrorAttribute:Attribute
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public ResponseErrorAttribute(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
