using Newtonsoft.Json;
using System;

namespace Bitmex.NET.Models.Socket
{
	public abstract class SocketMessage
	{
		[JsonProperty("op")]
		public string Operation { get; }
		[JsonProperty("args")]
		public object[] Arguments { get; }

		protected SocketMessage(OperationType operation, params object[] args)
		{

			Operation = Enum.GetName(typeof(OperationType), operation);
			Arguments = args;
		}
	}
}
