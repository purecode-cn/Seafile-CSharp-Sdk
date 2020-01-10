using System;
namespace SeafileClient.Common
{
    public class SeafileException: Exception
    {
        public SeafileException(int code, string message):base(message)
        {
            Code = code;
        }

        public int Code { get; }
    }
}
