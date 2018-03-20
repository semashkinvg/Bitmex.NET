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
	}
}
