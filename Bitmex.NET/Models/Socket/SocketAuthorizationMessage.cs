namespace Bitmex.NET.Models.Socket
{
    public sealed class SocketAuthorizationMessage : SocketMessage
    {
        public SocketAuthorizationMessage(string apiKey, long nonce, string sign) : base(OperationType.authKeyExpires, apiKey, nonce, sign)
        {

        }
    }
}
