using AutoMapper;

namespace Bitmex.NET.Example.Automapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<InstrumentProfile>();
                cfg.AddProfile<OrderProfile>();
                cfg.AddProfile<OrderBookProfile>();
            });
        }
    }
}
