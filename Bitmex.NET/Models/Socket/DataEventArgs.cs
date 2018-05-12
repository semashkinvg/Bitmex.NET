using Newtonsoft.Json.Linq;
using System;

namespace Bitmex.NET.Models.Socket
{
	public class DataEventArgs : EventArgs
	{
		public string TableName { get; }
		public JToken Data { get; }

		public DataEventArgs(string tableName, JToken data)
		{
			TableName = tableName;
			Data = data;
		}
	}
}
