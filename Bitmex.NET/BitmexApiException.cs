using Bitmex.NET.Dtos;
using System;

namespace Bitmex.NET
{
    public class BitmexApiException : Exception
    {
        public BitmexApiError Error { get; }

        public BitmexApiException(BitmexApiError error) : base($"{error.Error.Message}, Code:{error.Error.Name}")
        {
            Error = error;
        }
        public BitmexApiException(string resp) : base($"Bitmex returned error {resp}")
        {
            Error = new BitmexApiError { Error = new Error { Message = resp, Name = String.Empty } };
        }
    }
}
