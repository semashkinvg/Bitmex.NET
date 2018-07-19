namespace Bitmex.NET.Models.Socket
{
    public sealed class SocketAuthorizationMessage : SocketMessage
    {
        public SocketAuthorizationMessage(string apiKey, long expiresTime, string sign) : base(OperationType.authKeyExpires, apiKey, expiresTime, sign)
        {

        }
    }
}
