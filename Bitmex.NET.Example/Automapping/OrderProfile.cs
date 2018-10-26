using AutoMapper;
using Bitmex.NET.Dtos;
using Bitmex.NET.Example.Models;
using System;

namespace Bitmex.NET.Example.Automapping
{
    internal class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, OrderUpdateModel>()
                .ForMember(a => a.NotificationDateTime, a => a.MapFrom(b => DateTime.Now))
                .ForMember(a => a.Symbol, a => a.Condition(b => !string.IsNullOrWhiteSpace(b.Symbol)))
                .ForMember(a => a.Side, a => a.Condition(b => !string.IsNullOrWhiteSpace(b.Side)))
                .ForMember(a => a.Price, a => a.Condition(b => b.Price.HasValue))
                .ForMember(a => a.LeavesQty, a => a.Condition(b => b.LeavesQty.HasValue));
        }
    }
}
