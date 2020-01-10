using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
namespace SeafileClient
{
    public partial class Api : IApi
    {
        protected static readonly Exception forbidCallingDirectly = new NotImplementedException("Calling this method directly is forbidden.");

        public string ServiceRoot { get; set; }

        internal Api() { }
        
        public static IApi GetApi(string serviceRoot)
        {
            return RequestDecorator<IApi>.Create(new Api() { ServiceRoot = serviceRoot });
        }
    }
}
