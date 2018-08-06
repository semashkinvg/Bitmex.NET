namespace Bitmex.NET.Models.Socket
{
    internal sealed class SocketUnsubscriptionMessage : SocketMessage
    {
        internal SocketUnsubscriptionMessage(params object[] args) : base(OperationType.unsubscribe, args)
        {
        }
    }
}
