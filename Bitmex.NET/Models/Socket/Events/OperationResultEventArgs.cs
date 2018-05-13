using System;

namespace Bitmex.NET.Models.Socket.Events
{
	public class OperationResultEventArgs : EventArgs
	{
		public OperationType OperationType { get; }
		public bool Result { get; }
		public string Error { get; }
		public string Status { get; }
		public string[] Args { get; }

		public OperationResultEventArgs(OperationType operationType, bool result, string error, string status, string[] args)
		{
			OperationType = operationType;
			Result = result;
			Args = args;
			Error = error;
			Status = status;
		}
	}
}
