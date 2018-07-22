using System.Diagnostics;

namespace Bitmex.NET.Dtos.Socket
{
    [DebuggerDisplay("{" + nameof(Action) + "}")]
    public class BitmexSocketDataMessage<T>
    {
        public BitmexSocketDataMessage(BitmexActions action, T data)
        {
            Action = action;
            Data = data;
        }

        public BitmexActions Action { get; }

        public T Data { get; }
    }
}
