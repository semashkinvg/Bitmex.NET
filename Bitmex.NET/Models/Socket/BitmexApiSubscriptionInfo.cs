using Bitmex.NET.Dtos.Socket;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Bitmex.NET.Models.Socket
{
    public abstract class BitmexApiSubscriptionInfo
    {
        public string SubscriptionName { get; }

        public object[] Args { get; protected set; }

        public string SubscriptionWithArgs => (Args?.Any() ?? false) ? $"{SubscriptionName}:{string.Join(",", Args)}" : SubscriptionName;

        protected BitmexApiSubscriptionInfo(string subscriptionName)
        {
            SubscriptionName = subscriptionName;
        }

        public abstract void Execute(JToken data, BitmexActions action);
    }

    public class BitmexApiSubscriptionInfo<TResult> : BitmexApiSubscriptionInfo
        where TResult : class
    {
        public Action<BitmexSocketDataMessage<TResult>> Act { get; }

        public BitmexApiSubscriptionInfo(SubscriptionType subscriptionType, Action<BitmexSocketDataMessage<TResult>> act) : base(Enum.GetName(typeof(SubscriptionType), subscriptionType))
        {
            Act = act;
        }

        public BitmexApiSubscriptionInfo<TResult> WithArgs(params object[] args)
        {
            Args = args;
            return this;
        }

        public static BitmexApiSubscriptionInfo<TResult> Create(SubscriptionType subscriptionType, Action<BitmexSocketDataMessage<TResult>> act)
        {
            return new BitmexApiSubscriptionInfo<TResult>(subscriptionType, act);
        }

        public override void Execute(JToken data, BitmexActions action)
        {
            Act?.Invoke(new BitmexSocketDataMessage<TResult>(action, data.ToObject<TResult>()));
        }

    }
}
