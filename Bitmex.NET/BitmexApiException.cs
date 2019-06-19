using Bitmex.NET.Dtos;
using System;

namespace Bitmex.NET
{
    public class BitmexApiException : Exception
    {

        public int StatusCode { get; }
        public BitmexApiError Error { get; }
        public int? RetryAfterSeconds { get; internal set; }

        public BitmexApiException(int statusCode, BitmexApiError error) 
            : base($"{statusCode}: {error.Error.Message}, Code:{error.Error.Name}")
        {
            StatusCode = statusCode;
            Error = error;
        }
        public BitmexApiException(int statusCode, string resp) : base($"Bitmex returned error {statusCode}:{resp}")
        {
            StatusCode = statusCode;
            Error = new BitmexApiError { Error = new Error { Message = resp, Name = String.Empty } };
        }
    }
}
