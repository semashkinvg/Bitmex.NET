using AutoMapper;
using Bitmex.NET.Dtos;
using Bitmex.NET.Example.Models;

namespace Bitmex.NET.Example.Automapping
{
    internal class OrderBookProfile : Profile
    {
        public OrderBookProfile()
        {
            CreateMap<OrderBookDto, OrderBookModel>()
                .ForMember(a => a.Price, a => a.MapFrom(b => b.Price))
                .ForMember(a => a.Price, a => a.Condition(b => b.Price != 0))
                .ForMember(a => a.Size, a => a.MapFrom(b => b.Size))
                .ForMember(a => a.Price, a => a.Condition(b => b.Size != 0))
                .ForMember(a => a.Direction, a => a.MapFrom(b => b.Side))
                .ForMember(a => a.Id, a => a.MapFrom(b => b.Id));
        }
    }
}
