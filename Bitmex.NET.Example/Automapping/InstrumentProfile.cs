using AutoMapper;
using Bitmex.NET.Dtos;
using Bitmex.NET.Example.Models;

namespace Bitmex.NET.Example.Automapping
{
	internal class InstrumentProfile : Profile
	{
		public InstrumentProfile()
		{
			CreateMap<InstrumentDto, InstrumentModel>();
		}
	}
}
