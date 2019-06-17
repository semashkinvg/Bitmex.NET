using Bitmex.NET.Dtos;
using System;
using System.Net;

namespace Bitmex.NET
{
    public class BitmexApiException : Exception
    {
        public BitmexApiError Error { get; }
        public HttpStatusCode StatusCode { get; }

        public BitmexApiException(BitmexApiError error, HttpStatusCode statusCode) : base($"{error.Error.Message}, Code:{error.Error.Name}")
        {
            Error = error;
            StatusCode = statusCode;
        }
        public BitmexApiException(string resp, HttpStatusCode statusCode) : base($"Bitmex returned error {resp}")
        {
            Error = new BitmexApiError { Error = new Error { Message = resp, Name = String.Empty } };
            StatusCode = statusCode;
        }
    }
}
